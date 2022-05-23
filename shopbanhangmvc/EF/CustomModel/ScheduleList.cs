using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CustomModel
{
    public class ScheduleList
    {
        internal object matuyen;

        public string machuyen { get; set; }
        public string tenchuyen { get; set; }
        public string tentuyen { get; set; }

        public TimeSpan? giodi { get; set; }

        public TimeSpan? gioden { get; set; }

        public string noidi { get; set; }

        public string noiden { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ngaydi { get; set; }

    }
}
