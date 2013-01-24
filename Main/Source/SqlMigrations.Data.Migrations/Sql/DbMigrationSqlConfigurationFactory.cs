namespace SqlMigrations.Data.Migrations.Sql
{
    using System;
    using System.Collections.Generic;

    using NLib;

    public static class DbMigrationSqlConfigurationFactory
    {
        private static readonly Dictionary<string, MigrationSqlConfiguration> sqlConfigurations = new Dictionary<string, MigrationSqlConfiguration>();

        public static void SetSqlConfiguration(string providerInvariantName, MigrationSqlConfiguration migrationSqlConfiguration)
        {
            Check.Current.ArgumentNullException(providerInvariantName, "providerInvariantName");
            Check.Current.ArgumentNullException(migrationSqlConfiguration, "migrationSqlConfiguration");
            sqlConfigurations[providerInvariantName] = migrationSqlConfiguration;
        }

        public static MigrationSqlConfiguration GetSqlConfiguration(string providerInvariantName)
        {
            Check.Current.ArgumentNullException(providerInvariantName, "providerInvariantName");

            MigrationSqlConfiguration migrationSqlConfiguration;
            if (sqlConfigurations.TryGetValue(providerInvariantName, out migrationSqlConfiguration))
            {
                return migrationSqlConfiguration;
            }

            throw new Exception("No SQL Generator found for provider " + providerInvariantName); // TODO Throw better exception
        }
    }
}
