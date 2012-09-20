using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlMigrations.Data.Migrations.SqlServer.Sql
{
    using System.Reflection;

    using SqlMigrations.Data.Migrations.Models;
    using SqlMigrations.Data.Migrations.Sql;

    public class SqlServerMigrationSqlGenerator : MigrationSqlGenerator
    {
        private readonly List<MigrationStatement> statements = new List<MigrationStatement>();

        public override IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken)
        {
            foreach (var operation in migrationOperations)
            {
                var method = this.GetType().GetMethod("Generate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { operation.GetType() }, null);
                method.Invoke(this, new object[] { operation });
            }

            return this.statements;
        }

        protected virtual void Generate(CreateTableOperation createTableOperation)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("CREATE TABLE [dbo].[" + createTableOperation.Name + "] (");

            foreach (var column in createTableOperation.Columns)
            {
                sb.AppendFormat("[" + column.Name + "] [int] IDENTITY(1, 1) NOT NULL,");
            }

            sb.Remove(sb.Length - 1, 1); // Remove Last comma
            sb.AppendFormat(")");

            this.statements.Add(new MigrationStatement { Sql = sb.ToString(), SuppressTransaction = false });
        }
    }
}
