using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlMigrations.Data.Migrations.Models
{
    public class CreateTableOperation : MigrationOperation
    {
        private readonly string name;

        private readonly List<ColumnModel> columns = new List<ColumnModel>();

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

        public override bool IsDestructiveChange
        {
            get { return false; }
        }
    }
}
