using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DagStukkie.Models
{
    [Table("Gedagte")]
    public class Gedagte
    {
        [Key]
        public int idGedagte { get; set; }
        public string GedagteTeks { get; set; }
        public string ChangeOperator { get; set; }
        DateTime ChangeDate { get; set; }
        public string Status { get; set; }
    }

    public class GedagteContext : DbContext
    {
        public DbSet<Gedagte> Dagstukkie { get; set; }
    }
}