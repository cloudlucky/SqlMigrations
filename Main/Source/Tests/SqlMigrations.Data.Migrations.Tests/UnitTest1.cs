namespace SqlMigrations.Data.Migrations.Tests
{
    using System.Configuration;

    using SqlMigrations.Data.Migrations.Infrastructure;
    using SqlMigrations.Data.Migrations.Sql;
    using SqlMigrations.Data.Migrations.SqlServer;
    using SqlMigrations.Data.Migrations.SqlServer.Sql;

    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            var migrator = new DbMigrator(new MyDbConfiguration(ConfigurationManager.ConnectionStrings["DefaultConnection"]));
            migrator.Update();
        }
    }

    public class MyDbConfiguration : SqlServerDbMigrationsConfiguration
    {
        public MyDbConfiguration(ConnectionStringSettings connectionString)
            : base(connectionString)
        {
        }
    }

    public class CreateDropTableMigration : DbMigration
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
                    Id = c.Int(nullable: false, identity: true)
                })
                .PrimaryKey(x => x.Id);
        }

        public override long Id
        {
            get { return 1; }
        }

        public override string Name
        {
            get { return "FirstMigration"; }
        }
    }
}
