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

        public override void CreateTableIfNotExists()
        {
            using (var writer = Writer())
            {
                writer.WriteLine("IF OBJECT_ID('[__SqlMigrationsHistory]') IS NULL");
                writer.WriteLine("BEGIN");
                ++writer.Indent;
                writer.WriteLine("CREATE TABLE [dbo].[__SqlMigrationsHistory] (");
                writer.WriteLine(" [Id] [bigint] NOT NULL,");
                writer.WriteLine(" [Name] [nvarchar](MAX) NOT NULL,");
                writer.WriteLine(" [CreatedOn] [datetime2](7) NOT NULL,");
                writer.WriteLine(" [ProductVersion] [nvarchar](MAX) NOT NULL,");
                writer.WriteLine(" [GeneratedSql] [nvarchar](MAX) NOT NULL,");
                writer.WriteLine(" CONSTRAINT [PK___SqlMigrationsHistory] PRIMARY KEY CLUSTERED ([Id] ASC)");
                writer.WriteLine(")");
                --writer.Indent;
                writer.WriteLine("END");
                
                var dbFactory = DbProviderFactories.GetFactory(this.Configuration.ProviderName);
                using (var connection = dbFactory.CreateConnection())
                {
                    connection.ConnectionString = this.Configuration.ConnectionString;
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = writer.ToString();
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }  
        }

        protected override void FillInsertHitoryCommand(DbCommand cmd, Models.HistoryModel model)
        {
            base.FillInsertHitoryCommand(cmd, model);

            cmd.CommandText = "INSERT INTO [__SqlMigrationsHistory] ([Id], [Name], [CreatedOn], [ProductVersion], [GeneratedSql]) VALUES (@Id, @Name, @CreatedOn, @ProductVersion, @GeneratedSql)";
        }

        protected static IndentedTextWriter Writer()
        {
            return new IndentedTextWriter(new StringWriter());
        }
    }
}
