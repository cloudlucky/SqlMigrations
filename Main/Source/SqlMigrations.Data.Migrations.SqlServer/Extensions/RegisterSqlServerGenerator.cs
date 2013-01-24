namespace SqlMigrations.Data.Migrations.SqlServer.Extensions
{
    using SqlMigrations.Data.Migrations.Sql;
    using SqlMigrations.Data.Migrations.SqlServer.Sql;

    public static class DbMigrationsConfigurationExtensions
    {
        public static void RegisterSqlServerGenerator(this DbMigrationsConfiguration migration)
        {
            DbMigrationSqlConfigurationFactory.SetSqlConfiguration("System.Data.SqlClient", new SqlServerMigrationSqlConfiguration(migration));
        }
    }
}
