namespace SqlMigrations.Data.Migrations.Sql
{
    using System;
    using System.Collections.Generic;

    using SqlMigrations.Data.Migrations.Models;

    public abstract class MigrationSqlGenerator
    {
        public abstract IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken, Version databaseVersion);
    }
}
