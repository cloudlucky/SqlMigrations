namespace SqlMigrations.Data.Migrations.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("__SqlMigrationsHistory")]
    public class HistoryModel
    {
        [Column("Id", Order = 1)]
        public long Id { get; set; }

        [Column("Name", Order = 2)]
        public string Name { get; set; }

        [Column("CreatedOn", Order = 3)]
        public DateTime CreatedOn { get; set; }

        [Column("ProductVersion", Order = 4)]
        public Version ProductVersion { get; set; }

        [Column("GeneratedSql", Order = 5)]
        public string GeneratedSql { get; set; }
    }
}
