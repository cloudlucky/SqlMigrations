namespace SqlMigrations.Data.Migrations.SqlServer.Sql
{
    using SqlMigrations.Data.Migrations.Sql;

    public class SqlServerMigrationSqlConfiguration : MigrationSqlConfiguration
    {
        private readonly MigrationSqlInspection inspection;

        private readonly MigrationHistoryRepository historyRepository;

        public SqlServerMigrationSqlConfiguration(DbMigrationsConfiguration configuration)
            : base(configuration)
        {
            this.inspection = new SqlServerMigrationSqlInspection(configuration);
            this.historyRepository = new SqlServerMigrationHistoryRepository(configuration);
        }

        public override MigrationSqlGenerator SqlGenerator
        {
            get { return new SqlServerMigrationSqlGenerator(); }
        }

        public override MigrationSqlInspection SqlInspection
        {
            get { return this.inspection; }
        }

        public override MigrationHistoryRepository HistoryRepository
        {
            get { return this.historyRepository; }
        }
    }
}
