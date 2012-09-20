namespace SqlMigrations.Data.Migrations.Builders
{
    using System;
    using System.Linq.Expressions;

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

        public TableBuilder<TColumns> PrimaryKey(Expression<Func<TColumns, Object>> keyExpression, string name = null, Object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }
    }
}
