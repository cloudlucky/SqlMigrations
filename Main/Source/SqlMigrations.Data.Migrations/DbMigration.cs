namespace SqlMigrations.Data.Migrations
{
    using System;
    using System.Collections.Generic;

    using SqlMigrations.Data.Migrations.Builders;
    using SqlMigrations.Data.Migrations.Models;

    public abstract class DbMigration
    {
        private readonly List<MigrationOperation> operations = new List<MigrationOperation>();

        internal IEnumerable<MigrationOperation> Operations
        {
            get { return this.operations; }
        }

        public abstract void Down();

        public abstract void Up();

        protected TableBuilder<TColumns> CreateTable<TColumns>(string name, Func<ColumnBuilder, TColumns> columnsAction, object anonymousArguments = null)
        {
            var createTableOperation = new CreateTableOperation(name, anonymousArguments);
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

        protected void DropTable(string name, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }
    }
}
