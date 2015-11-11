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
    public class Categories
    {
        public int ID { get; set; }
        public String Name { get; set; }

        public virtual List<FAQs> Faqs { get; set; }
    }

    public class FAQs
    {
        public int ID { get; set; }
        public String Question { get; set; }
        public String Answer { get; set; }
        public int CategoryId { get; set; } // foreign key from Category

        public virtual Categories Category { get; set; }
    }

    public class Requests
    {
        public int ID { get; set; }
        public String SenderFirstName { get; set; }
        public String SenderLastName { get; set; }
        public String SenderEmail { get; set; }
        public String Subject { get; set; }
        public String Question { get; set; }
        public DateTime Date { get; set; }
        public bool Answered { get; set; }
    }

    public class FAQContext : DbContext
    {
        public FAQContext()
          : base("name=FAQ")
        {
            Database.CreateIfNotExists();
        }
        
        public DbSet<Categories> Categories { get; set; }
        public DbSet<FAQs> FAQs { get; set; }
        public DbSet<Requests> Requests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}