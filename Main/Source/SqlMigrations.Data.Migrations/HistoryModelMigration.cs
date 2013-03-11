namespace SqlMigrations.Data.Migrations
{
    public class HistoryModelMigration : DbMigration
    {
        public override void Down()
        {
            this.DropTableIfExists("__SqlMigrationsHistory");
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
                        ProductVersion = c.String(nullable: false),
                        GeneratedSql = c.String(nullable: false)
                    })
                .PrimaryKey(pk => pk.Id);
        }

        public override long Id
        {
            get { return long.MinValue; }
        }

        public override string Name
        {
            get { return "Create History Model"; }
        }
    }
}
