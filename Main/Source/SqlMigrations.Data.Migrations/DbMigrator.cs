namespace SqlMigrations.Data.Migrations
{
    using System;
    using System.Collections.Generic;
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
            this.EnsureHistory();

            ExecuteUpdate(GetMigrations(this.configuration), this.configuration);
        }

        private static IEnumerable<DbMigration> GetMigrations(DbMigrationsConfiguration configuration)
        {
            return configuration.MigrationsAssemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => !x.IsAbstract && x.IsSubclassOf(typeof(DbMigration)) && x.GetInterfaces().Any(y => y == typeof(IMigrationMetadata)))
                .Select(Activator.CreateInstance)
                .Cast<IMigrationMetadata>()
                .OrderBy(x => x.Id)
                .Cast<DbMigration>()
                .ToList();
        }

        private static void ExecuteUpdate(IEnumerable<DbMigration> migrations, DbMigrationsConfiguration configuration, bool addHistory = true)
        {
            var sqlConfiguration = DbMigrationSqlConfigurationFactory.GetSqlConfiguration(configuration.ProviderName);
            var dbFactory = DbProviderFactories.GetFactory(configuration.ProviderName);

            using (var connection = dbFactory.CreateConnection())
            {
                connection.ConnectionString = configuration.ConnectionString;
                var cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                connection.Open();

                foreach (var migration in migrations)
                {
                    try
                    {
                        migration.SetDatabaseVersion(sqlConfiguration.SqlInspection.GetDatabaseVersion());
                        migration.Up();
                        var statements = sqlConfiguration.SqlGenerator.Generate(migration.Operations, string.Empty);

                        foreach (var statement in statements)
                        {
                            cmd.CommandText = statement.Sql;
                            cmd.ExecuteNonQuery();
                        }

                        if (addHistory)
                        {
                            // TODO add History Row
                        }
                    }
                    catch (Exception ex)
                    {
                        migration.Down();
                        throw;
                    }
                }
            }
        }

        public override void Update(int targetMigration)
        {
            throw new NotImplementedException();
        }

        private void EnsureHistory()
        {
            var internalConfiguration = new DbMigrationsConfiguration(this.configuration.ConnectionString, this.configuration.ProviderName);

            ExecuteUpdate(GetMigrations(internalConfiguration), internalConfiguration, false);
        }
    }
}
