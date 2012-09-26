namespace SqlMigrations.Data.Migrations.Builders
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using NLib;
    using NLib.Collections.Generic.Extensions;

    using SqlMigrations.Data.Migrations.Extensions;
    using SqlMigrations.Data.Migrations.Models;

    public class TableBuilder<TColumns>
    {
        private readonly CreateTableOperation createTableOperation;
        private readonly DbMigration migration;

        public TableBuilder(CreateTableOperation createTableOperation, DbMigration migration)
        {
            this.createTableOperation = createTableOperation;
            this.migration = migration;
        }

        public TableBuilder<TColumns> ForeignKey(string principalTable, Expression<Func<TColumns, object>> dependentKeyExpression, bool cascadeDelete = false, string name = null, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        public TableBuilder<TColumns> Index(Expression<Func<TColumns, object>> indexExpression, bool unique = false, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        public TableBuilder<TColumns> PrimaryKey(Expression<Func<TColumns, object>> keyExpression, string name = null, object anonymousArguments = null)
        {
            CheckError.ArgumentNullException(keyExpression, "keyExpression");

            var addPrimaryKeyOperation = new AddPrimaryKeyOperation(anonymousArguments)
                {
                    Name = name,
                };

            keyExpression.GetPropertyAccessList().Select(p => p.Name).ForEach(addPrimaryKeyOperation.Columns.Add);

            this.createTableOperation.PrimaryKey = addPrimaryKeyOperation;

            return this;
        }
    }
}
