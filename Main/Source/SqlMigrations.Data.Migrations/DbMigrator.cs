namespace SqlMigrations.Data.Migrations
{
    using System;

    using SqlMigrations.Data.Migrations.Infrastructure;

    public class DbMigrator : MigratorBase
    {
        private readonly DbMigrationsConfiguration configuration;

        public DbMigrator(DbMigrationsConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public override DbMigrationsConfiguration Configuration
        {
            get { return this.configuration; }
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Update(int targetMigration)
        {
            throw new NotImplementedException();
        }
    }
}
