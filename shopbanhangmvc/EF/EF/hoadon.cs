namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hoadon")]
    public partial class hoadon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hoadon()
        {
            vexes = new HashSet<vexe>();
        }

        [Key]
        public int mahd { get; set; }

        [StringLength(50)]
        public string hoten { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        public double? tongtien { get; set; }

        public int? soluongve { get; set; }

        [StringLength(10)]
        public string machuyen { get; set; }

        [StringLength(10)]
        public string sdt { get; set; }

        public int? tinhtrang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaydat { get; set; }

        public virtual account account { get; set; }

        public virtual chuyenxe chuyenxe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vexe> vexes { get; set; }
    }
}
