using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlMigrations.Data.Migrations.Models
{
    public class ColumnModel
    {
        public virtual string Name { get; set; }

        public virtual bool IsIdentity { get; set; }
    }
}
