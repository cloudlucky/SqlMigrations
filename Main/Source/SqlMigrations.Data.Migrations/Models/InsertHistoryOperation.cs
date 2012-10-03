namespace SqlMigrations.Data.Migrations.Models
{
    using System.Reflection;

    using SqlMigrations.Data.Migrations.Extensions;

    public class InsertHistoryOperation : HistoryOperation
    {
        private static readonly string AssemblyVersion = Assembly.GetExecutingAssembly().GetInformationalVersion();

        public InsertHistoryOperation(string table, long migrationId, object anonymousArguments = null)
            : base(table, migrationId, anonymousArguments)
        {
        }

        private string ProductVersion
        {
            get { return AssemblyVersion; }
        }

        public override bool IsDestructiveChange
        {
            get { return false; }
        }
    }
}
