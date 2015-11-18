using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GodtSkoddFAQ_mappe3_s198611.Models
{
    public class Category
    {
        public int id { get; set; }

        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,30}$")]
        public String name { get; set; }
    }

    public class FAQ
    {
        public int id { get; set; }

        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,30}$")]
        public String question { get; set; }

        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,30}$")]
        public String answer { get; set; }

        [Required]
        [RegularExpression("^[0-9]{1,3}$")]
        public int categoryId { get; set; }
    }

    public class Request    // Sender and Message
    {
        public int id { get; set; }

        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,30}$")]
        public String senderFirstName { get; set; }

        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,30}$")]
        public String senderLastName { get; set; }

        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,30}$")]
        public String senderEmail { get; set; }

        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,30}$")]
        public String subject { get; set; }

        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,30}$")]
        public String question { get; set; }

        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,30}$")]
        public DateTime date { get; set; }

        [Required]
        public bool answered { get; set; }
    }
}