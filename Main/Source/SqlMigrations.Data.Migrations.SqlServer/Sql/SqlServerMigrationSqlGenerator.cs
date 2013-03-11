namespace SqlMigrations.Data.Migrations.SqlServer.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Linq;

    using NLib;

    using SqlMigrations.Data.Migrations.Extensions;
    using SqlMigrations.Data.Migrations.Models;
    using SqlMigrations.Data.Migrations.Sql;
    using SqlMigrations.Data.Migrations.Writers;

    public class SqlServerMigrationSqlGenerator : MigrationSqlGenerator
    {
        private Dictionary<string, string> typeMapping;

        private readonly List<MigrationStatement> statements = new List<MigrationStatement>();

        public override IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken, Version databaseVersion)
        {
            if (databaseVersion < new Version(10, 0))
            {
                throw new NotSupportedException(string.Format("This provider support SQL Server 2008 to latest version only. The current database version is {0}.", databaseVersion));
            }

            this.typeMapping = new Dictionary<string, string>
                {
                    { typeof(byte).Name, "tinyint" },
                    { typeof(byte[]).Name, "varbinary" },
                    { typeof(bool).Name, "bit" },
                    { typeof(char).Name, "nchar" },
                    { typeof(DateTime).Name, "datetime2" },
                    { typeof(DateTimeOffset).Name, "datetime2" },
                    { typeof(decimal).Name, "decimal" },
                    { typeof(double).Name, "float" },
                    { typeof(float).Name, "real" },
                    { typeof(Guid).Name, "uniqueidentifier" },
                    { typeof(int).Name, "int" },
                    { typeof(long).Name, "bigint" },
                    { typeof(object).Name, "sql_variant" },
                    { typeof(short).Name, "smallint" },
                    { typeof(string).Name, "nvarchar" },
                    { typeof(TimeSpan).Name, "time" },
                    { typeof(XDocument).Name, "xml" }

                    // etc... http://msdn.microsoft.com/en-us/library/cc716729.aspx
                };

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

            if (!string.IsNullOrWhiteSpace(column.StoreType))
            {
                writer.Write(" " + this.Quote(column.StoreType));
            }
            else if ((column.ClrType == typeof(string) || column.ClrType == typeof(char)) && column.IsUnicode.HasValue && !column.IsUnicode.Value)
            {
                writer.Write(" " + this.Quote(this.typeMapping[column.ClrType.Name].Substring(1)));
            }
            else if ((column.ClrType == typeof(string) || column.ClrType == typeof(byte[])) && column.IsFixedLength.HasValue && column.IsFixedLength.Value)
            {
                // NOTE String can be non-unicode and fixed length.
                writer.Write(" " + this.Quote(this.typeMapping[column.ClrType.Name].Replace("var", string.Empty)));
            }
            else
            {
                writer.Write(" " + this.Quote(this.typeMapping[column.ClrType.Name]));
            }

            if (column.ClrType == typeof(DateTime) || column.ClrType == typeof(DateTimeOffset) || column.ClrType == typeof(TimeSpan))
            {
                writer.Write("(" + (column.Precision.HasValue ? column.Precision.Value.ToString(CultureInfo.InvariantCulture) : "7") + ")");
            }
            else if (column.ClrType == typeof(decimal))
            {
                writer.Write("(" + (column.Precision.HasValue ? column.Precision.Value.ToString(CultureInfo.InvariantCulture) : "38") + ", " + (column.Scale.HasValue ? column.Scale.Value.ToString(CultureInfo.InvariantCulture) : "8") + " )");
            }
            else if (column.ClrType == typeof(string) || column.ClrType == typeof(byte[]))
            {
                writer.Write("(" + (column.MaxLength.HasValue ? column.MaxLength.Value.ToString(CultureInfo.InvariantCulture) : "MAX") + ")");
            }
            // Note Check IsMaxLength

            if (column.IsIdentity)
            {
                writer.Write(column.ClrType == typeof(Guid)
                    ? " DEFAULT NEWSEQUENTIALID()"
                    : " IDENTITY(1, 1)");
            }

            if (column.DefaultValue != null)
            {
                writer.Write(" DEFAULT '" + column.DefaultValue + "'");
            }

            if (column.DefaultValueSql != null)
            {
                writer.Write(" DEFAULT " + column.DefaultValueSql);
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
            Check.Current.ArgumentNullException(writer, "writer");
            this.Statement(writer.ToString(), false);
        }

        protected void Statement(string sql, bool suppressTransaction = false)
        {
            Check.Current.ArgumentNullOrWhiteSpaceException(sql, "sql");
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
