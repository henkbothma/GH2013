using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DagStukkie.Models
{
    [Table("Boodskap")]
    public class Boodskap
    {
        //[Key]
        public int BoodskapID { get; set; }
        public string BoodskapTeks { get; set; }
        public string ChangeOperator { get; set; }
        DateTime ChangeDate { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Master> Masters { get; set; }
    }

}