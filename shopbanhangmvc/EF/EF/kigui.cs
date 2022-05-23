namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kigui")]
    public partial class kigui
    {
        [Key]
        public int makg { get; set; }

        [StringLength(50)]
        public string tennguoigui { get; set; }

        [StringLength(20)]
        public string sdtnguoigui { get; set; }

        [StringLength(50)]
        public string tennguoinhan { get; set; }

        [StringLength(20)]
        public string sdtnguoinhan { get; set; }

        [StringLength(200)]
        public string diachinguoinhan { get; set; }

        [StringLength(10)]
        public string machuyen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngay { get; set; }

        public int? chiphi { get; set; }

        [StringLength(10)]
        public string nvsuly { get; set; }

        public int? tinhtrang { get; set; }

        public virtual chuyenxe chuyenxe { get; set; }

        public virtual nhanvien nhanvien { get; set; }
    }
}
