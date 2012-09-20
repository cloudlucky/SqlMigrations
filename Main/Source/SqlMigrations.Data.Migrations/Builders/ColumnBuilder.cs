namespace SqlMigrations.Data.Migrations.Builders
{
    using System;

    using SqlMigrations.Data.Migrations.Models;

    public class ColumnBuilder
    {
        public ColumnModel Int(bool? nullable = null, bool identity = false, int? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return new ColumnModel { IsIdentity = identity }; // TODO
        }
    }
}