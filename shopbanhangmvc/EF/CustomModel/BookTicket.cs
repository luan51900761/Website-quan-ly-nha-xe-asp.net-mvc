using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CustomModel
{
    public class BookTicket
    {
        public int mahd { get; set; }
        public int mave { get; set; }

        public string machuyenxe { get; set; }

        public string tenghe { get; set; }

        public int? tinhtrang { get; set; }
        [Required]
        public string SDT { get; set; }

        public string username { get; set; }

        public string gheduocchon { get; set; }
        public double gia { get; set; }
        public string tongtien { get; set; }

        public int soluong { get; set; }
        [Required]
        public string hoten { get; set; }

    }
}
