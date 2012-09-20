namespace SqlMigrations.Data.Migrations
{
    using System;
    using System.Data.Common;
    using System.Linq;

    using SqlMigrations.Data.Migrations.Infrastructure;
    using SqlMigrations.Data.Migrations.Sql;

    public class DbMigrator : MigratorBase
    {
        private readonly DbMigrationsConfiguration configuration;

        public DbMigrator(DbMigrationsConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public override DbMigrationsConfiguration Configuration
        {
            get { return this.configuration; }
        }

        public override void Update()
        {
            var migrations = this.Configuration.GetType().Assembly.GetTypes()
                .Where(x => !x.IsAbstract && x.IsSubclassOf(typeof(DbMigration)))
                .Select(Activator.CreateInstance)
                .Cast<DbMigration>()
                .ToList();

            var sqlGenerator = DbMigrationSqlGeneratorFactory.GetSqlGenerator(this.configuration.ProviderName);

            foreach (var migration in migrations)
            {
                migration.Up();
                var statements = sqlGenerator.Generate(migration.Operations, string.Empty);

                var dbFactory = DbProviderFactories.GetFactory(this.configuration.ProviderName);

                foreach(var statement in statements)
                {
                    using (var connection = dbFactory.CreateConnection())
                    {
                        connection.ConnectionString = this.configuration.ConnectionString;
                        var cmd = connection.CreateCommand();
                        cmd.CommandText = statement.Sql;
                        cmd.CommandType = System.Data.CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public override void Update(int targetMigration)
        {
            throw new NotImplementedException();
        }
    }
}
