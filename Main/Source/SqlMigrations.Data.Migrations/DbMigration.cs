namespace SqlMigrations.Data.Migrations
{
    using System;
    using System.Collections.Generic;

    using SqlMigrations.Data.Migrations.Builders;
    using SqlMigrations.Data.Migrations.Infrastructure;
    using SqlMigrations.Data.Migrations.Models;

    public abstract class DbMigration : IDbMigration, IMigrationMetadata
    {
        private readonly List<MigrationOperation> operations = new List<MigrationOperation>();

        internal IEnumerable<MigrationOperation> Operations
        {
            get { return this.operations; }
        }

        public Version DatabaseVersion { get; internal set; }

        public abstract void Down();

        public abstract void Up();

        protected internal void AddColumn(string table, string name, Func<ColumnBuilder, ColumnModel> columnAction, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected internal void AddColumnIfNotExists(string table, string name, Func<ColumnBuilder, ColumnModel> columnAction, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected void AddForeignKey(string dependentTable, string dependentColumn, string principalTable, string principalColumn = null, bool cascadeDelete = false, string name = null, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected internal void AlterColumn(string table, string name, Func<ColumnBuilder, ColumnModel> columnAction, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected internal void AddForeignKey(string dependentTable, string[] dependentColumns, string principalTable, string[] principalColumns = null, bool cascadeDelete = false, string name = null, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected internal void AddPrimaryKey(string table, string column, string name = null, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }
        
        protected internal void AddPrimaryKey(string table, string[] columns, string name = null, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }
        
        protected internal void CreateIndex(string table, string column, bool unique = false, string name = null, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected internal void CreateIndex(string table, string[] columns, bool unique = false, string name = null, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected TableBuilder<TColumns> CreateTable<TColumns>(string name, Func<ColumnBuilder, TColumns> columnsAction, object anonymousArguments = null)
        {
            var createTableOperation = new CreateTableOperation(name, anonymousArguments);

            return this.CreateTableBuilder(createTableOperation, columnsAction);
        }

        protected TableBuilder<TColumns> CreateTableIfNotExists<TColumns>(string name, Func<ColumnBuilder, TColumns> columnsAction, object anonymousArguments = null)
        {
            var createTableOperation = new CreateTableIfNotExistsOperation(name, anonymousArguments);

            return this.CreateTableBuilder(createTableOperation, columnsAction);
        }

        private TableBuilder<TColumns> CreateTableBuilder<TColumns>(CreateTableOperation createTableOperation, Func<ColumnBuilder, TColumns> columnsAction)
        {
            this.operations.Add(createTableOperation);

            var columns = columnsAction(new ColumnBuilder());
            foreach (var column in columns.GetType().GetProperties())
            {
                var columnModel = column.GetValue(columns, null) as ColumnModel;

                if (columnModel == null)
                {
                    break;
                }

                columnModel.Name = column.Name;

                createTableOperation.Columns.Add(columnModel);
            }

            return new TableBuilder<TColumns>(createTableOperation, this);
        }

        protected internal void DropColumn(string table, string name, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected internal void DropForeignKey(string dependentTable, string name, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected internal void DropForeignKey(string dependentTable, string dependentColumn, string principalTable, string principalColumn = null, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected internal void DropForeignKey(string dependentTable, string[] dependentColumns, string principalTable, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }
        
        protected internal void DropIndex(string table, string name, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected internal void DropIndex(string table, string[] columns, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }
        
        protected internal void DropPrimaryKey(string table, string name, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected internal void DropPrimaryKey(string table, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected void DropTable(string name, object anonymousArguments = null)
        {
            this.operations.Add(new DropTableOperation(name, anonymousArguments));
        }

        protected void DropTableIfExists(string name, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected internal void MoveTable(string name, string newSchema, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected internal void RenameColumn(string table, string name, string newName, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected internal void RenameTable(string name, string newName, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected internal void Sql(string sql, bool suppressTransaction = false, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        public abstract long Id { get; }

        public abstract string Name { get; }
    }
}
