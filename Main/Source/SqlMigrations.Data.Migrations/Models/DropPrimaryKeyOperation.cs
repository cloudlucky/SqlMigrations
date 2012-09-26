namespace SqlMigrations.Data.Migrations.Models
{
    using NLib.Collections.Generic.Extensions;

    public class DropPrimaryKeyOperation : PrimaryKeyOperation
    {
        public DropPrimaryKeyOperation(object anonymousArguments)
            : base(anonymousArguments)
        {
        }

        public override MigrationOperation Inverse
        {
            get
            {
                var operation = new AddPrimaryKeyOperation(null)
                    {
                        Name = this.Name,
                        Table = this.Table
                    };

                Columns.ForEach(x => operation.Columns.Add(x));

                return operation;
            }
        }
    }
}
