using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DagStukkie.Models
{
    [Table("Titel")]
    public class Titel
    {
        [Key]
        public int idTitel { get; set; }
        public char TitelTeks { get; set; }
        public char ChangeOperator { get; set; }
        public DateTime ChangeDate { get; set; }
        public char Status { get; set; }
    }

    public class TitelContext : DbContext
    {
        public DbSet<Titel> Dagstukkie { get; set; }
    }
}