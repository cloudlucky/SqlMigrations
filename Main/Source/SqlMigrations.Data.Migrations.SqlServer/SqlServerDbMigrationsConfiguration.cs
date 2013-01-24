namespace SqlMigrations.Data.Migrations.SqlServer
{
    using System.Configuration;

    using SqlMigrations.Data.Migrations.SqlServer.Extensions;

    public class SqlServerDbMigrationsConfiguration : DbMigrationsConfiguration
    {
        public SqlServerDbMigrationsConfiguration(ConnectionStringSettings connectionString)
            : base(connectionString)
        {
            this.RegisterSqlServerGenerator();
        }
    }
}
