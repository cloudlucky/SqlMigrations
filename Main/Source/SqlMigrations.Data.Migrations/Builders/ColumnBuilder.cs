namespace SqlMigrations.Data.Migrations.Builders
{
    using System;
    using System.Xml.Linq;

    using SqlMigrations.Data.Migrations.Models;

    /// <summary>
    /// Builder that is used to configure a column.
    /// </summary>
    public class ColumnBuilder
    {
        /// <summary>
        /// Creates a new column definition to store Binary data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="maxLength">The maximum allowable length of the array data.</param>
        /// <param name="fixedLength">Value indicating whether or not all data should be padded to the maximum length.</param>
        /// <param name="isMaxLength">Value indicating whether or not the maximum length supported by the database provider should be used.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="timestamp">Value indicating whether or not this column should be configured as a timestamp.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel Binary(bool? nullable = null, int? maxLength = null, bool? fixedLength = null, bool? isMaxLength = null, byte[] defaultValue = null, string defaultValueSql = null, bool timestamp = false, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(byte[]), nullable: nullable, maxLength: maxLength, fixedLength: fixedLength, isMaxLength: isMaxLength, defaultValue: defaultValue, defaultValueSql: defaultValueSql, timestamp: timestamp, name: name, storeType: storeType);
        }

        /// <summary>
        /// Creates a new column definition to store Boolean data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel Boolean(bool? nullable = null, bool? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(bool), nullable: nullable, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        /// <summary>
        /// Creates a new column definition to store <see cref="byte"/> data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="identity">Value indicating whether or not the database will generate values for this column during insert.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel Byte(bool? nullable = null, bool identity = false, byte? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(byte), nullable: nullable, identity: identity, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        /// <summary>
        /// Creates a new column definition to store <see cref="char"/> data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="unicode">Value indicating whether or not the column supports Unicode content.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel Char(bool? nullable = null, bool? unicode = null, char defaultValue = '\0', string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(char), nullable: nullable, maxLength: 1/*, fixedLength: fixedLength, isMaxLength: isMaxLength*/, unicode: unicode, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        /// <summary>
        /// Creates a new column definition to store <see cref="DateTime"/> data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="precision">The precision of the column.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel DateTime(bool? nullable = null, byte? precision = null, DateTime? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(DateTime), nullable: nullable, precision: precision, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        /// <summary>
        /// Creates a new column definition to store <see cref="DateTimeOffset"/> data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="precision">The numeric precision of the column.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel DateTimeOffset(bool? nullable = null, byte? precision = null, DateTimeOffset? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(DateTimeOffset), nullable: nullable, precision: precision, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        /// <summary>
        /// Creates a new column definition to store <see cref="decimal"/> data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="precision">The numeric precision of the column.</param>
        /// <param name="scale">The numeric scale of the column.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <param name="identity">Value indicating whether or not the database will generate values for this column during insert.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel Decimal(bool? nullable = null, byte? precision = null, byte? scale = null, decimal? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null, bool identity = false)
        {
            return BuildColumn(typeof(decimal), nullable: nullable, precision: precision, scale: scale, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType, identity: identity);
        }

        /// <summary>
        /// Creates a new column definition to store <see cref="double"/> data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel Double(bool? nullable = null, double? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(double), nullable: nullable, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        /// <summary>
        /// Creates a new column definition to store <see cref="Guid"/> data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="identity">Value indicating whether or not the database will generate values for this column during insert.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel Guid(bool? nullable = null, bool identity = false, Guid? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(Guid), nullable: nullable, identity: identity, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        /// <summary>
        /// Creates a new column definition to store <see cref="float"/> data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel Single(bool? nullable = null, float? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(float), nullable: nullable, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        /// <summary>
        /// Creates a new column definition to store <see cref="short"/> data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="identity">Value indicating whether or not the database will generate values for this column during insert.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel Short(bool? nullable = null, bool identity = false, short? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(short), nullable: nullable, identity: identity, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        /// <summary>
        /// Creates a new column definition to store <see cref="int"/> data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="identity">Value indicating whether or not the database will generate values for this column during insert.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel Int(bool? nullable = null, bool identity = false, int? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(int), nullable: nullable, identity: identity, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        /// <summary>
        /// Creates a new column definition to store <see cref="long"/> data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="identity">Value indicating whether or not the database will generate values for this column during insert.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel Long(bool? nullable = null, bool identity = false, long? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(long), nullable: nullable, identity: identity, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        /// <summary>
        /// Creates a new column definition to store <see cref="string"/> data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="maxLength">The maximum allowable length of string data.</param>
        /// <param name="fixedLength">Value indicating whether or not all data should be padded to the maximum length.</param>
        /// <param name="isMaxLength">Value indicating whether or not the maximum length supported by the database provider should be used.</param>
        /// <param name="unicode">Value indicating whether or not the column supports Unicode content.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel String(bool? nullable = null, int? maxLength = null, bool? fixedLength = null, bool? isMaxLength = null, bool? unicode = null, string defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(string), nullable: nullable, maxLength: maxLength, fixedLength: fixedLength/*, isMaxLength: isMaxLength*/, unicode: unicode, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        /// <summary>
        /// Creates a new column definition to store <see cref="TimeSpan"/> data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="precision">The numeric precision of the column.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel Time(bool? nullable = null, byte? precision = null, TimeSpan? defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(TimeSpan), nullable: nullable, precision: precision, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        //public ColumnModel Geography(bool? nullable = null, DbGeography defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public ColumnModel Geometry(bool? nullable = null, DbGeometry defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Creates a new column definition to store Xml data.
        /// </summary>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        public ColumnModel Xml(bool? nullable = null, XDocument defaultValue = null, string defaultValueSql = null, string name = null, string storeType = null)
        {
            return BuildColumn(typeof(XDocument), nullable: nullable, defaultValue: defaultValue, defaultValueSql: defaultValueSql, name: name, storeType: storeType);
        }

        /// <summary>
        /// Creates a new column definition to store Xml data.
        /// </summary>
        /// <param name="clrType">Type of the column.</param>
        /// <param name="nullable">Value indicating whether or not the column allows null values.</param>
        /// <param name="defaultValue">Constant value to use as the default value for this column.</param>
        /// <param name="defaultValueSql">SQL expression used as the default value for this column.</param>
        /// <param name="maxLength">The maximum allowable length of the array data.</param>
        /// <param name="precision">The numeric precision of the column.</param>
        /// <param name="scale">The numeric scale of the column.</param>
        /// <param name="unicode">Value indicating whether or not the column supports Unicode content.</param>
        /// <param name="fixedLength">Value indicating whether or not all data should be padded to the maximum length.</param>
        /// <param name="isMaxLength">Value indicating whether or not all data should be the maximum length.</param>
        /// <param name="identity">Value indicating whether or not the database will generate values for this column during insert.</param>
        /// <param name="timestamp">Value indicating whether or not this column should be configured as a timestamp.</param>
        /// <param name="name">The name of the column.</param>
        /// <param name="storeType">Provider specific data type to use for this column.</param>
        /// <returns>The column definition.</returns>
        private static ColumnModel BuildColumn(Type clrType, bool? nullable, object defaultValue, string defaultValueSql = null, int? maxLength = null, byte? precision = null, byte? scale = null, bool? unicode = null, bool? fixedLength = null, bool? isMaxLength = null, bool identity = false, bool timestamp = false, string name = null, string storeType = null)
        {
            return new ColumnModel(clrType)
            {
                IsNullable = nullable,
                MaxLength = maxLength,
                Precision = precision,
                Scale = scale,
                IsUnicode = unicode,
                IsFixedLength = fixedLength,
                IsMaxLength = isMaxLength,
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