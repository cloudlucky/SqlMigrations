namespace SqlMigrations.Data.Migrations.Models
{
    public class DropTableOperation : MigrationOperation
    {
        private readonly string name;

        public DropTableOperation(string name, object anonymousArguments)
            : base(anonymousArguments)
        {
            this.name = name;
        }

        public override MigrationOperation Inverse
        {
            get { return new CreateTableOperation(this.name, null); }
        }

        public virtual string Name
        {
            get { return this.name; }
        }

        public override bool IsDestructiveChange
        {
            get { return true; }
        }
    }
}
