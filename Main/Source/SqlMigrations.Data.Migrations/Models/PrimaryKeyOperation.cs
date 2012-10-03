namespace SqlMigrations.Data.Migrations.Models
{
    using System.Collections.Generic;

    using NLib;

    public abstract class PrimaryKeyOperation : MigrationOperation
    {
        private readonly List<string> columns = new List<string>();

        private string table;

        private string name;

        protected PrimaryKeyOperation(object anonymousArguments)
            : base(anonymousArguments)
        {
        }

        public IList<string> Columns
        {
            get { return this.columns; }
        }

        public override bool IsDestructiveChange
        {
            get { return false; }
        }

        public string Name
        {
            get { return this.name ?? this.DefaultName; }
            set { this.name = value; }
        }

        public string Table
        {
            get
            {
                return this.table;
            }

            set
            {
                CheckError.ArgumentNullException(!string.IsNullOrWhiteSpace(value), "!string.IsNullOrWhiteSpace(value)");
                this.table = value;
            }
        }

        protected string DefaultName
        {
            get { return string.Format("PK_{0}", this.Table); }
        }
    }
}
