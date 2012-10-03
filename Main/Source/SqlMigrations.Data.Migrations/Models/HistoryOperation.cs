namespace SqlMigrations.Data.Migrations.Models
{
    public abstract class HistoryOperation : MigrationOperation
    {
        private readonly string table;

        private readonly long migrationId;

        protected HistoryOperation(string table, long migrationId, object anonymousArguments = null)
            : base(anonymousArguments)
        {
            this.table = table;
            this.migrationId = migrationId;
        }

        public string Table
        {
            get { return this.table; }
        }

        public long MigrationId
        {
            get { return this.migrationId; }
        }

        public override bool IsDestructiveChange
        {
            get { return false; }
        }
    }
}
