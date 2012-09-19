namespace SqlMigrations.Data.Migrations.Builders
{
    using System;
    using System.Linq.Expressions;

    public class TableBuilder<TColumns>
    {
        public TableBuilder<TColumns> PrimaryKey(Expression<Func<TColumns, Object>> keyExpression, string name = null, Object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }
    }
}
