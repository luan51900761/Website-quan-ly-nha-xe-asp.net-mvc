namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chuyenxe")]
    public partial class chuyenxe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public chuyenxe()
        {
            hoadons = new HashSet<hoadon>();
            kiguis = new HashSet<kigui>();
        }

        [Key]
        [StringLength(10)]
        public string machuyen { get; set; }

        [StringLength(50)]
        public string tenchuyen { get; set; }

        [StringLength(10)]
        public string matuyen { get; set; }

        public TimeSpan? giodi { get; set; }

        public TimeSpan? gioden { get; set; }

        [StringLength(10)]
        public string manv { get; set; }

        [StringLength(10)]
        public string maxe { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaydi { get; set; }

        [StringLength(10)]
        public string matx { get; set; }

        public virtual nhanvien nhanvien { get; set; }

        public virtual tuyenxe tuyenxe { get; set; }

        public virtual tuyenxe tuyenxe1 { get; set; }

        public virtual nhanvien nhanvien1 { get; set; }

        public virtual xe xe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoadon> hoadons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kigui> kiguis { get; set; }
    }
}
