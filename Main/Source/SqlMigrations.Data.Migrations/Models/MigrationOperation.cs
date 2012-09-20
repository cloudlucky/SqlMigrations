using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLib.Collections.Generic.Extensions;

namespace SqlMigrations.Data.Migrations.Models
{
    using System.Reflection;

    public abstract class MigrationOperation
    {
        private readonly IDictionary<string, object> anonymousArguments = new Dictionary<string, object>();

        protected MigrationOperation(object anonymousArguments)
        {
            if (anonymousArguments != null)
            {
                anonymousArguments.GetType().GetProperties().ForEach(p => this.anonymousArguments.Add(p.Name, p.GetValue(anonymousArguments, null)));
            }
        }

        public IDictionary<string, object> AnonymousArguments
        {
            get { return this.anonymousArguments; }
        }

        public virtual MigrationOperation Inverse
        {
            get { return null; }
        }

        public abstract bool IsDestructiveChange { get; }
    }
}
