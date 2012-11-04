namespace SqlMigrations.Data.Migrations.SqlServer.Sql
{
    using SqlMigrations.Data.Migrations.Sql;

    public class SqlServerMigrationSqlConfiguration : MigrationSqlConfiguration
    {
        private readonly MigrationSqlInspection inspection;

        public SqlServerMigrationSqlConfiguration(DbMigrationsConfiguration confirguration)
            : base(confirguration)
        {
            this.inspection = new SqlServerMigrationSqlInspection(confirguration);
        }

        public override MigrationSqlGenerator SqlGenerator
        {
            get { return new SqlServerMigrationSqlGenerator(); }
        }

        public override MigrationSqlInspection SqlInspection
        {
            get { return this.inspection; }
        }
    }
}
