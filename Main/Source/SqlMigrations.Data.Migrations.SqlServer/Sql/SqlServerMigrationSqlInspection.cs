namespace SqlMigrations.Data.Migrations.SqlServer.Sql
{
    using System;
    using System.Data.Common;

    using SqlMigrations.Data.Migrations.Sql;

    public class SqlServerMigrationSqlInspection : MigrationSqlInspection
    {
        public SqlServerMigrationSqlInspection(DbMigrationsConfiguration configuration)
            : base(configuration)
        {
        }

        public override Version GetDatabaseVersion()
        {
            var dbFactory = DbProviderFactories.GetFactory(this.Configuration.ProviderName);
            using (var connection = dbFactory.CreateConnection())
            {
                connection.ConnectionString = this.Configuration.ConnectionString;
                var cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT SERVERPROPERTY('productversion')";
                connection.Open();
                var version = cmd.ExecuteScalar().ToString();

                return new Version(version);
            }
        }
    }
}
