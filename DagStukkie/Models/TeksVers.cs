using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DagStukkie.Models
{
    [Table("TeksVers")]
    public class TeksVers
    {
        [Key]
        public int idTeksVers { get; set; }
        public char TeksVersNommer { get; set; }
        public char TeksVersTeks { get; set; }
        public char ChangeOperator { get; set; }
        public DateTime ChangeDate { get; set; }
        public char Status { get; set; }
    }

    public class TeksVersContext : DbContext
    {
        public DbSet<TeksVers> Dagstukkie { get; set; }
    }
}