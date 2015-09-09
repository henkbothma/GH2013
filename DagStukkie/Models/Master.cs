using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DagStukkie.Models
{
    [Table("Master")]
    public class Master
    {
        [Key]
        public int idMaster { get; set; }

        public DateTime DateToday { get; set; }
        public int BoodskapUID { get; set; }
        public int GebedUID { get; set; }
        public int GedagteUID { get; set; }
        public int SkrifUID { get; set; }
        public int TeksVersUID { get; set; }
        public int TitelUID { get; set; }
        public char ChangeOperator { get; set; }
        public DateTime ChangeDate { get; set; }
        public char Status { get; set; }
    }

    public class MasterContext : DbContext
    {
        public DbSet<Master> Dagstukkie { get; set; }
    }
}