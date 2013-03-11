namespace SqlMigrations.Data.Migrations.Sql
{
    using System.Data;
    using System.Data.Common;

    using SqlMigrations.Data.Migrations.Models;

    public abstract class MigrationHistoryRepository
    {
        protected MigrationHistoryRepository(DbMigrationsConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        protected DbMigrationsConfiguration Configuration { get; private set; }

        public virtual void InsertHistory(HistoryModel model)
        {
            var dbFactory = DbProviderFactories.GetFactory(this.Configuration.ProviderName);
            using (var connection = dbFactory.CreateConnection())
            {
                connection.ConnectionString = this.Configuration.ConnectionString;
                var cmd = connection.CreateCommand();
                this.FillInsertHistoryCommand(cmd, model);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected virtual void FillInsertHistoryCommand(DbCommand cmd, HistoryModel model)
        {
            cmd.CommandType = CommandType.Text;

            var idParameter = cmd.CreateParameter();
            idParameter.DbType = DbType.Int64;
            idParameter.ParameterName = "@Id";
            idParameter.Value = model.Id;
            cmd.Parameters.Add(idParameter);

            var nameParameter = cmd.CreateParameter();
            nameParameter.DbType = DbType.String;
            nameParameter.ParameterName = "@Name";
            nameParameter.Value = model.Name;
            cmd.Parameters.Add(nameParameter);

            var createdOnParameter = cmd.CreateParameter();
            createdOnParameter.DbType = DbType.DateTime2;
            createdOnParameter.ParameterName = "@CreatedOn";
            createdOnParameter.Value = model.CreatedOn;
            cmd.Parameters.Add(createdOnParameter);

            var productVersionParameter = cmd.CreateParameter();
            productVersionParameter.DbType = DbType.String;
            productVersionParameter.ParameterName = "@ProductVersion";
            productVersionParameter.Value = model.ProductVersion.ToString();
            cmd.Parameters.Add(productVersionParameter);

            var generatedSqlParameter = cmd.CreateParameter();
            generatedSqlParameter.DbType = DbType.String;
            generatedSqlParameter.ParameterName = "@GeneratedSql";
            generatedSqlParameter.Value = model.GeneratedSql;
            cmd.Parameters.Add(generatedSqlParameter);
        }
    }
}
