﻿namespace SqlMigrations.Data.Migrations.Infrastructure
{
    public interface IMigrationMetadata
    {
        long Id { get; }

        string Name { get; }
    }
}
