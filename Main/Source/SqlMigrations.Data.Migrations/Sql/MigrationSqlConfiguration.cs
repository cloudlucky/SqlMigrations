namespace SqlMigrations.Data.Migrations.Sql
{
    public abstract class MigrationSqlConfiguration
    {
        protected MigrationSqlConfiguration(DbMigrationsConfiguration confirguration)
        {
            this.Confirguration = confirguration;
        }

        public DbMigrationsConfiguration Confirguration { get; private set; }

        public abstract MigrationSqlGenerator SqlGenerator { get; }

        public abstract MigrationSqlInspection SqlInspection { get; }

        public abstract MigrationHistoryRepository HistoryRepository { get; }
    }
}
