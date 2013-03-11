namespace SqlMigrations.Data.Migrations.SqlServer.Sql
{
    using System.Data.Common;
    using System.IO;

    using SqlMigrations.Data.Migrations.Sql;
    using SqlMigrations.Data.Migrations.Writers;

    public class SqlServerMigrationHistoryRepository : MigrationHistoryRepository
    {
        public SqlServerMigrationHistoryRepository(DbMigrationsConfiguration configuration)
            : base(configuration)
        {
        }

        protected static IndentedTextWriter Writer()
        {
            return new IndentedTextWriter(new StringWriter());
        }

        protected override void FillInsertHistoryCommand(DbCommand cmd, Models.HistoryModel model)
        {
            base.FillInsertHistoryCommand(cmd, model);

            cmd.CommandText = "INSERT INTO [__SqlMigrationsHistory] ([Id], [Name], [CreatedOn], [ProductVersion], [GeneratedSql])" 
                            + "VALUES (@Id, @Name, @CreatedOn, @ProductVersion, @GeneratedSql)";
        }
    }
}
