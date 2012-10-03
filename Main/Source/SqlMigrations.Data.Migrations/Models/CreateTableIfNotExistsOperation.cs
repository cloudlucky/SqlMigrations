namespace SqlMigrations.Data.Migrations.Models
{
    public class CreateTableIfNotExistsOperation : CreateTableOperation
    {
        public CreateTableIfNotExistsOperation(string name, object anonymousArguments)
            : base(name, anonymousArguments)
        {
        }
    }
}
