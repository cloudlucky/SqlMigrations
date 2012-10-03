namespace SqlMigrations.Data.Migrations.History
{
    using SqlMigrations.Data.Migrations.Infrastructure;

    public class HistoryDbMigration : DbMigration, IMigrationMetadata
    {
        public override void Down()
        {
            //this.DropTable("__SqlMigrationsHistory");
        }

        public override void Up()
        {
            this.CreateTableIfNotExists(
                "__SqlMigrationsHistory", 
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ProductVersion = c.String()
                    })
                .PrimaryKey(x => x.Id);
        }

        public long Id
        {
            get { return -1; }
        }

        public string Name
        {
            get { return "__SqlMigrationsHistory"; }
        }
    }
}
