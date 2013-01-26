namespace SqlMigrations.Data.Migrations.Sql
{
    public abstract class MigrationSqlConfiguration
    {
        protected MigrationSqlConfiguration(DbMigrationsConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public DbMigrationsConfiguration Configuration { get; private set; }

        public abstract MigrationSqlGenerator SqlGenerator { get; }

        public abstract MigrationSqlInspection SqlInspection { get; }

        public abstract MigrationHistoryRepository HistoryRepository { get; }
    }
}
