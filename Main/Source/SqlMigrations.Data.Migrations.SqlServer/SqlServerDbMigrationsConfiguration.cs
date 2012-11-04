namespace SqlMigrations.Data.Migrations.SqlServer
{
    using System.Configuration;

    public class SqlServerDbMigrationsConfiguration : DbMigrationsConfiguration
    {
        public SqlServerDbMigrationsConfiguration(ConnectionStringSettings connectionString)
            : base(connectionString)
        {
            this.RegisterSqlServerGenerator();
        }
    }
}
