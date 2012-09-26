namespace SqlMigrations.Data.Migrations.Builders
{
    using System;

    using SqlMigrations.Data.Migrations.Models;

    public class ColumnBuilder
    {
        public ColumnModel Binary(bool? nullable = null, int? maxLength = null, bool? fixedLength = null, bool? isMaxLength = null, byte[] defaultValue = null, string defaultValueSql = null, bool timestamp = false, string name = null, string storeType = null)
        {
            throw new NotImplementedException();
        }

        public ColumnModel Boolean(bool? nullable = null, bool? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            throw new NotImplementedException();
        }

        public ColumnModel Byte(bool? nullable = null, bool identity = false, byte? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            throw new NotImplementedException();
        }

        public ColumnModel DateTime(bool? nullable = null, byte? precision = null, DateTime? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            throw new NotImplementedException();
        }

        public ColumnModel Decimal(bool? nullable = null, byte? precision = null, byte? scale = null, Decimal? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null, bool identity = false)
        {
            throw new NotImplementedException();
        }

        public ColumnModel Double(bool? nullable = null, double? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            throw new NotImplementedException();
        }

        public ColumnModel Guid(bool? nullable = null, bool identity = false, Guid? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            throw new NotImplementedException();
        }

        public ColumnModel Single(bool? nullable = null, float? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            throw new NotImplementedException();
        }

        public ColumnModel Short(bool? nullable = null, bool identity = false, short? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            throw new NotImplementedException();
        }

        public ColumnModel Int(bool? nullable = null, bool identity = false, int? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(nullable: nullable, identity: identity, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        public ColumnModel Long(bool? nullable = null, bool identity = false, long? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            throw new NotImplementedException();
        }

        public ColumnModel String(bool? nullable = null, int? maxLength = null, bool? fixedLength = null, bool? isMaxLength = null, bool? unicode = null, string defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            throw new NotImplementedException();
        }

        public ColumnModel Time(bool? nullable = null, byte? precision = null, TimeSpan? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            throw new NotImplementedException();
        }

        public ColumnModel DateTimeOffset(bool? nullable = null, byte? precision = null, DateTimeOffset? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            throw new NotImplementedException();
        }

        //public ColumnModel Geography(bool? nullable = null, DbGeography defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public ColumnModel Geometry(bool? nullable = null, DbGeometry defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        //{
        //    throw new NotImplementedException();
        //}

        private static ColumnModel BuildColumn(bool? nullable, object defaultValue, string defaultValueSql = null, int? maxLength = null, byte? precision = null, byte? scale = null, bool? unicode = null, bool? fixedLength = null, bool identity = false, bool timestamp = false, string name = null, string storeType = null)
        {
            return new ColumnModel
            {
                IsNullable = nullable,
                MaxLength = maxLength,
                Precision = precision,
                Scale = scale,
                IsUnicode = unicode,
                IsFixedLength = fixedLength,
                IsIdentity = identity,
                DefaultValue = defaultValue,
                DefaultValueSql = defaultValueSql,
                IsTimestamp = timestamp,
                Name = name,
                StoreType = storeType
            };
        }
    }
}