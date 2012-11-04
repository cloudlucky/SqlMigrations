namespace SqlMigrations.Data.Migrations.Sql
{
    public abstract class MigrationSqlConfiguration
    {
        protected MigrationSqlConfiguration(DbMigrationsConfiguration confirguration)
        {
            this.Confirguration = confirguration;
        }

        protected DbMigrationsConfiguration Confirguration { get; private set; }

        public abstract MigrationSqlGenerator SqlGenerator { get; }

        public abstract MigrationSqlInspection SqlInspection { get; }
    }
}
