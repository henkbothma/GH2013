﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DagStukkie.Models
{
    [Table("Skrif")]
    public class Skrif
    {
        [Key]
        public int idSkrif { get; set; }

        public char SkrifTeks { get; set; }
        public char BybelTeks { get; set; }
        public char ChangeOperator { get; set; }
        public DateTime ChangeDate { get; set; }
        public char Status { get; set; }
    }

    public class SkrifContext : DbContext
    {
        public DbSet<Skrif> Dagstukkie { get; set; }
    }
}