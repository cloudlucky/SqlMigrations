namespace SqlMigrations.Data.Migrations.Sql
{
    using System;
    using System.Collections.Generic;

    using NLib;

    public static class DbMigrationSqlGeneratorFactory
    {
        private static readonly Dictionary<string, MigrationSqlGenerator> sqlGenerators = new Dictionary<string, MigrationSqlGenerator>();

        public static void SetSqlGenerator(string providerInvariantName, MigrationSqlGenerator migrationSqlGenerator)
        {
            CheckError.ArgumentNullException(providerInvariantName, "providerInvariantName");
            CheckError.ArgumentNullException(migrationSqlGenerator, "migrationSqlGenerator");
            sqlGenerators[providerInvariantName] = migrationSqlGenerator;
        }

        public static MigrationSqlGenerator GetSqlGenerator(string providerInvariantName)
        {
            CheckError.ArgumentNullException(providerInvariantName, "providerInvariantName");

            MigrationSqlGenerator migrationSqlGenerator;
            if (sqlGenerators.TryGetValue(providerInvariantName, out migrationSqlGenerator))
            {
                return (MigrationSqlGenerator)Activator.CreateInstance(migrationSqlGenerator.GetType()); // TODO Fixme
            }

            throw new Exception("No SQL Generator found for provider " + providerInvariantName); // TODO Throw better exception
        }
    }
}
