﻿namespace SqlMigrations.Data.Migrations.SqlServer.Sql
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    using NLib;

    using SqlMigrations.Data.Migrations.Extensions;
    using SqlMigrations.Data.Migrations.Models;
    using SqlMigrations.Data.Migrations.Sql;
    using SqlMigrations.Data.Migrations.Writers;

    public class SqlServerMigrationSqlGenerator : MigrationSqlGenerator
    {
        private readonly List<MigrationStatement> statements = new List<MigrationStatement>();

        public override IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken)
        {
            foreach (var operation in migrationOperations)
            {
                var method = this.GetType().GetMethod("Generate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { operation.GetType() }, null);

                if (method == null)
                {
                    throw new MissingMethodException(this.GetType().Name, "Generate(" + operation.GetType().Name + ")");
                }

                method.Invoke(this, new object[] { operation });
            }

            return this.statements;
        }

        protected virtual void Generate(CreateTableOperation createTableOperation)
        {
            using (var writer = Writer())
            {
                this.Generate(createTableOperation, writer);

                this.Statement(writer);
            }
        }

        private void Generate(CreateTableOperation createTableOperation, IndentedTextWriter writer)
        {
            writer.WriteLine("CREATE TABLE [dbo].[" + createTableOperation.Name + "] (");
            ++writer.Indent;

            var columnCount = 0;
            foreach (var column in createTableOperation.Columns)
            {
                if (columnCount > 0)
                {
                    writer.Write(',');
                }

                this.Generate(column, writer);
                writer.WriteLine();

                ++columnCount;
            }

            if (createTableOperation.PrimaryKey != null)
            {
                writer.Write(",");
                writer.Write("CONSTRAINT ");
                writer.Write(this.Quote(createTableOperation.PrimaryKey.Name));
                writer.Write(" PRIMARY KEY (");
                writer.Write(createTableOperation.PrimaryKey.Columns.Join(this.Quote, ", "));
                writer.WriteLine(")");
            }

            --writer.Indent;
            writer.WriteLine(")");
        }

        protected virtual void Generate(CreateTableIfNotExistsOperation createTableOperation)
        {
            using (var writer = Writer())
            {
                writer.WriteLine("IF OBJECT_ID('" + this.Quote(createTableOperation.Name) + "') IS NULL");
                writer.WriteLine("BEGIN");
                ++writer.Indent;
                this.Generate((CreateTableOperation)createTableOperation, writer);
                --writer.Indent;
                writer.WriteLine("END");

                this.Statement(writer);
            }
        }

        private void Generate(ColumnModel column, IndentedTextWriter writer)
        {
            writer.Write(this.Quote(column.Name));
            writer.Write(" " + this.Quote("int"));

            if (column.IsIdentity)
            {
                writer.Write(" IDENTITY(1, 1)");
            }

            if (!column.IsNullable.HasValue || column.IsNullable.Value)
            {
                writer.Write(" NULL");
            }
            else
            {
                writer.Write(" NOT NULL");
            }
        }

        protected virtual string Quote(string identifier)
        {
            return "[" + identifier + "]";
        }

        protected void Statement(IndentedTextWriter writer)
        {
            CheckError.ArgumentNullException(writer != null, "writer");
            this.Statement(writer.InnerWriter.ToString(), false);
        }

        protected void Statement(string sql, bool suppressTransaction = false)
        {
            CheckError.ArgumentNullOrWhiteSpaceException(sql, "sql");
            this.statements.Add(new MigrationStatement
            {
                Sql = sql,
                SuppressTransaction = suppressTransaction
            });
        }

        protected static IndentedTextWriter Writer()
        {
            return new IndentedTextWriter(new StringWriter());
        }
    }
}
