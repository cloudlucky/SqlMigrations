namespace SqlMigrations.Data.Migrations.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("__SqlMigrationsHistory")]
    public class HistoryModel
    {
        [Column(Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Column(Order = 2)]
        public string Name { get; set; }

        [Column(Order = 3)]
        public DateTime CreatedOn { get; set; }

        [Column(Order = 4)]
        public Version ProductVersion { get; set; }

        [Column(Order = 5)]
        public string GeneratedSql { get; set; }
    }
}
