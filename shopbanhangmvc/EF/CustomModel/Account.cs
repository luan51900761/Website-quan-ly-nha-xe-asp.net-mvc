using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF.CustomModel
{
    public class Account
    {
        //y/c NHẬP
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}