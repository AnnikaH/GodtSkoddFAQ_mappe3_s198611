using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Core.EntityClient;
using System.Data.Common;

namespace GodtSkoddFAQ_mappe3_s198611.Models
{
    /*public class Kunde
    {
        [Key]
        public int id { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string adresse { get; set; }
        public string postnr { get; set; }

        public virtual Poststed poststed { get; set; }
    }

    public class Poststed
    {
        [Key]
        public string postnr { get; set; }
        public string poststed { get; set; }

        public virtual List<Kunde> kunder { get; set; }
    }*/

    public class FAQContext : DbContext
    {
        public FAQContext()
          : base("name=FAQ")
        {
            Database.CreateIfNotExists();
        }
        
        //public DbSet<Kunde> Kunder { get; set; }
        //public DbSet<Poststed> Poststeder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}