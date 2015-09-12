using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DagStukkie.Models
{
    [Table("TeksVers")]
    public class TeksVers
    {
        //[Key]
        public int TeksVersID { get; set; }
        public string TeksVersNommer { get; set; }
        public string TeksVersTeks { get; set; }
        public string ChangeOperator { get; set; }
        public DateTime ChangeDate { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Master> Masters { get; set; }
    }

}