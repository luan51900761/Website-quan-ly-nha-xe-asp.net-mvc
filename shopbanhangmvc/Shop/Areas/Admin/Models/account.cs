using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Areas.Admin.Models
{
    public class account
    {
        //y/c NHẬP
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public string role { get; set; }
    }
}