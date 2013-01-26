namespace SqlMigrations.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using SqlMigrations.Data.Migrations.Infrastructure;
    using SqlMigrations.Data.Migrations.Models;
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
            ExecuteUpdate(GetMigrations(this.configuration), this.configuration);
        }

        private static IEnumerable<DbMigration> GetMigrations(DbMigrationsConfiguration configuration)
        {
            return configuration.MigrationsAssemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => !x.IsAbstract && x.IsSubclassOf(typeof(DbMigration)))
                .Select(Activator.CreateInstance)
                .Cast<DbMigration>()
                .OrderBy(x => x.Id)
                .ToList();
        }

        private static void ExecuteUpdate(IEnumerable<DbMigration> migrations, DbMigrationsConfiguration configuration)
        {
            var sqlConfiguration = DbMigrationSqlConfigurationFactory.GetSqlConfiguration(configuration.ProviderName);
            sqlConfiguration.HistoryRepository.CreateTableIfNotExists();

            var dbFactory = DbProviderFactories.GetFactory(configuration.ProviderName);
            var version = Assembly.GetExecutingAssembly().GetName().Version;

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
                        var statementBuilder = new StringBuilder();
                        migration.DatabaseVersion = sqlConfiguration.SqlInspection.GetDatabaseVersion();
                        migration.Up();
                        var statements = sqlConfiguration.SqlGenerator.Generate(migration.Operations, string.Empty, migration.DatabaseVersion);

                        foreach (var statement in statements)
                        {
                            statementBuilder.Append(statement.Sql);
                            cmd.CommandText = statement.Sql;
                            cmd.ExecuteNonQuery();
                        }

                        var history = new HistoryModel
                            {
                                CreatedOn = DateTime.Now,
                                GeneratedSql = statementBuilder.ToString(),
                                Id = migration.Id,
                                Name = migration.Name,
                                ProductVersion = version
                            };
                        sqlConfiguration.HistoryRepository.InsertHistory(history);
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
    }
}
