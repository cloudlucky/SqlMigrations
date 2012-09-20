namespace SqlMigrations.Data.Migrations.Sql
{
    public class MigrationStatement
    {
        public string Sql { get; set; }

        public bool SuppressTransaction { get; set; }
    }
}