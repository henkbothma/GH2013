using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DagStukkie.Models
{
    [Table("Skrif")]
    public class Skrif
    {
        //[Key]
        public int SkrifID { get; set; }
        public string SkrifTeks { get; set; }
        public string BybelTeks { get; set; }
        public string ChangeOperator { get; set; }
        public DateTime ChangeDate { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Master> Masters { get; set; }
    }

}