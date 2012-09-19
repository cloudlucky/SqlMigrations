namespace SqlMigrations.Data.Migrations.Infrastructure
{
    public abstract class MigratorBase
    {
        public abstract DbMigrationsConfiguration Configuration { get; }

        public abstract void Update();

        public abstract void Update(int targetMigration);
    }
}
