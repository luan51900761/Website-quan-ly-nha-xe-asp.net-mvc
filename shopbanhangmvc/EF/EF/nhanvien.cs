namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nhanvien")]
    public partial class nhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhanvien()
        {
            chuyenxes = new HashSet<chuyenxe>();
            chuyenxes1 = new HashSet<chuyenxe>();
            kiguis = new HashSet<kigui>();
        }

        [Key]
        [StringLength(10)]
        public string manv { get; set; }

        [StringLength(50)]
        public string tennv { get; set; }

        public DateTime? ngaysinh { get; set; }

        [StringLength(3)]
        public string gioitinh { get; set; }

        [StringLength(100)]
        public string diachi { get; set; }

        [StringLength(10)]
        public string cmnd { get; set; }

        [StringLength(10)]
        public string dienthoai { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(10)]
        public string maloainv { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(200)]
        public string hinhanh { get; set; }

        public virtual account account { get; set; }

        public virtual account account1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chuyenxe> chuyenxes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chuyenxe> chuyenxes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kigui> kiguis { get; set; }

        public virtual loainv loainv { get; set; }

        public virtual loainv loainv1 { get; set; }
    }
}
