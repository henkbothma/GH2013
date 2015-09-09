using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DagStukkie.Models
{
       [Table("Gebed")]
    public class Gebed
    {
           [Key]
           public int idGebed { get; set; }
           public char GebedsTeks { get; set; }
           public char ChangeOperator { get; set; }
           public DateTime ChangeDate { get; set; }
           public char Status { get; set; }
    }

    public class GebedContext : DbContext
    {
        public DbSet<Gebed> Dagstukkie { get; set; }
    }
}

