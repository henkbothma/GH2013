using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;

namespace DagStukkie.Models
{
    [Table("Titel")]
    public class Titel
    {
        //[Key]
        public int TitelID { get; set; }
        public string TitelTeks { get; set; }
        public string ChangeOperator { get; set; }
        public DateTime ChangeDate { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Master> Masters { get; set; }
    }

}