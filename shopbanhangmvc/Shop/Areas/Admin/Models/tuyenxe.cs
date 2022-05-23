using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Areas.Admin.Models
{
    public class tuyenxe
    {
        [Required]
        private string matuyen { get; set; }
        [Required]

        private string tentuyen { get; set; }
        [Required]

        private string diemdi { get; set; }
        [Required]

        private string diemden { get; set; }
        [Required]

        private double banggia { get; set; }

        private string image { get; set; }
        [Required]
        private double thoigian { get; set; }

    }
}