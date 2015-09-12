using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DagStukkie.Models
{
    [Table("Master")]
    public class Master
    {
        //[Key]
        public int MasterID { get; set; }
        DateTime DateToday { get; set; }
        public int BoodskapID { get; set; }
        public int GebedID { get; set; }
        public int GedagteID { get; set; }
        public int SkrifID { get; set; }
        public int TeksVersID { get; set; }
        public int TitelID { get; set; }
        public string ChangeOperator { get; set; }
        DateTime ChangeDate { get; set; }
        public string Status { get; set; }

        public virtual Boodskap Boodskap { get; set; }
        public virtual Gebed Gebed { get; set; }
        public virtual Gedagte Gedagte { get; set; }
        public virtual Skrif Skrif { get; set; }
        public virtual TeksVers TeksVers { get; set; }
        public virtual Titel Titel { get; set; }
    }

}