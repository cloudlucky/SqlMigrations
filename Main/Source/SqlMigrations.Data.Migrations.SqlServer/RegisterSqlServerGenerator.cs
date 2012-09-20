namespace SqlMigrations.Data.Migrations.SqlServer
{
    using SqlMigrations.Data.Migrations.Sql;
    using SqlMigrations.Data.Migrations.SqlServer.Sql;

    public static class RegisterSqlServerGenerator
    {
        static RegisterSqlServerGenerator()
        {
            DbMigrationSqlGeneratorFactory.SetSqlGenerator("System.Data.SqlClient", new SqlServerMigrationSqlGenerator());
        }
    }
}
