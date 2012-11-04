namespace SqlMigrations.Data.Migrations
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Reflection;

    public class DbMigrationsConfiguration
    {
        protected DbMigrationsConfiguration()
        {
            this.MigrationsAssemblies = new List<Assembly> { this.GetType().Assembly };
        }

        public DbMigrationsConfiguration(ConnectionStringSettings connectionString)
            : this(connectionString.ConnectionString, connectionString.ProviderName)
        {
        }

        public DbMigrationsConfiguration(string connectionString, string providerName)
            : this()
        {
            this.ConnectionString = connectionString;
            this.ProviderName = providerName;
        }

        public ICollection<Assembly> MigrationsAssemblies { get; private set; }

        public string ConnectionString { get; protected set; }

        public string ProviderName { get; protected set; }
    }
}
