namespace SqlMigrations.Data.Migrations.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SqlMigrations.Data.Migrations.Infrastructure;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    public class CreateDropTableMigration : DbMigration, IMigrationMetadata
    {
        public override void Down()
        {
            this.DropTable("Foo");
        }

        public override void Up()
        {
            this.CreateTable(
                "Foo",
                c => new
                {
                    Id = c.Int(identity: true)
                })
                .PrimaryKey(x => x.Id);
        }

        long IMigrationMetadata.Id
        {
            get { return 1; }
        }
    }
}
