namespace SqlMigrations.Data.Migrations.Sql
{
    using System;

    public abstract class MigrationSqlInspection
    {
        protected MigrationSqlInspection(DbMigrationsConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        protected DbMigrationsConfiguration Configuration { get; private set; }

        public abstract Version GetDatabaseVersion();
    }
}
