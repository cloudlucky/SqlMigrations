namespace SqlMigrations.Data.Migrations.Models
{
    using System.Collections.Generic;

    using NLib;

    public class CreateTableOperation : MigrationOperation
    {
        private readonly string name;

        private readonly List<ColumnModel> columns = new List<ColumnModel>();

        private AddPrimaryKeyOperation primaryKey;

        public CreateTableOperation(string name, object anonymousArguments)
            : base(anonymousArguments)
        {
            this.name = name;
        }

        public virtual string Name 
        { 
            get { return this.name; } 
        }

        public virtual ICollection<ColumnModel> Columns
        {
            get { return this.columns; }
        }

        public override MigrationOperation Inverse
        {
            get { return new DropTableOperation(this.Name, (object)null); }
        }

        public override bool IsDestructiveChange
        {
            get { return false; }
        }

        public AddPrimaryKeyOperation PrimaryKey
        {
            get
            {
                return this.primaryKey;
            }

            set
            {
                CheckError.ArgumentNullException(value != null, "value != null");
                this.primaryKey = value;
                this.primaryKey.Table = this.Name;
            }
        }
    }
}
