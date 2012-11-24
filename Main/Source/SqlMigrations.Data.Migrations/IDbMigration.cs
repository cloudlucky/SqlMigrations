namespace SqlMigrations.Data.Migrations
{
    public interface IDbMigration
    {
        void Down();

        void Up();
    }
}