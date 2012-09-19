namespace SqlMigrations.Data.Migrations
{
    using System;
    using SqlMigrations.Data.Migrations.Builders;

    public abstract class DbMigration
    {
        public abstract void Down();

        public abstract void Up();

        protected TableBuilder<TColumns> CreateTable<TColumns>(string name, Func<ColumnBuilder, TColumns> columnsAction, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }

        protected void DropTable(string name, object anonymousArguments = null)
        {
            throw new NotImplementedException();
        }
    }
}
