namespace SqlMigrations.Data.Migrations.Models
{
    using System;

    public class ColumnModel
    {
        public ColumnModel(Type type)
        {
            this.ClrType = type;
        }

        public Type ClrType { get; private set; }

        public virtual string Name { get; set; }

        public virtual string StoreType { get; set; }

        public virtual bool? IsNullable { get; set; }

        public virtual bool IsIdentity { get; set; }

        public virtual int? MaxLength { get; set; }

        public virtual byte? Precision { get; set; }

        public virtual byte? Scale { get; set; }

        public virtual object DefaultValue { get; set; }

        public virtual string DefaultValueSql { get; set; }

        public virtual bool? IsFixedLength { get; set; }

        public virtual bool? IsMaxLength { get; set; }

        public virtual bool? IsUnicode { get; set; }

        public virtual bool IsTimestamp { get; set; }
    }
}
