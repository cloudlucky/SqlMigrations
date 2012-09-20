namespace SqlMigrations.Data.Migrations.Tests
{
    using System.Configuration;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SqlMigrations.Data.Migrations.Infrastructure;
    using SqlMigrations.Data.Migrations.Sql;
    using SqlMigrations.Data.Migrations.SqlServer.Sql;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var migrator = new DbMigrator(new MyDbConfiguration(ConfigurationManager.ConnectionStrings["DefaultConnection"]));
            migrator.Update();
        }
    }

    public class MyDbConfiguration : DbMigrationsConfiguration
    {
        public MyDbConfiguration(ConnectionStringSettings connectionString)
            : base(connectionString)
        {
            DbMigrationSqlGeneratorFactory.SetSqlGenerator("System.Data.SqlClient", new SqlServerMigrationSqlGenerator()); 
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
                /*.PrimaryKey(x => x.Id)*/;
        }

        long IMigrationMetadata.Id
        {
            get { return 1; }
        }

        public string Name
        {
            get { return "FirstMigration"; }
        }
    }
}
