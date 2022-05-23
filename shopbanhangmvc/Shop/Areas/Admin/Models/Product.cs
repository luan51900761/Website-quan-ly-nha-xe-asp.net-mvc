using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Areas.Admin.Models
{
    public class Product
    {
        [Required]
        public string id { get; set; }

        [Required]
        public string brand { get; set; }

        [Required]
        public string name { get; set; }

        public string picture { get; set; }

        public string description { get; set; }

        public string origin { get; set; }

        public DateTime dateExport { get; set; }
        public int status { get; set; }
        public int price { get; set; } 
    }
}