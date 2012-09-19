﻿namespace SqlMigrations.Data.Migrations
{
    using System.Configuration;

    public class DbMigrationsConfiguration
    {
        protected DbMigrationsConfiguration()
        {
        }

        public DbMigrationsConfiguration(ConnectionStringSettings connectionString)
            : this(connectionString.ConnectionString, connectionString.ProviderName)
        {
        }

        public DbMigrationsConfiguration(string connectionString, string providerName)
        {
            this.ConnectionString = connectionString;
            this.ProviderName = providerName;
        }

        public string ConnectionString { get; protected set; }

        public string ProviderName { get; protected set; }
    }
}