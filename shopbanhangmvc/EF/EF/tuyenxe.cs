namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tuyenxe")]
    public partial class tuyenxe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tuyenxe()
        {
            chuyenxes = new HashSet<chuyenxe>();
            chuyenxes1 = new HashSet<chuyenxe>();
        }

        [Key]
        [StringLength(10)]
        public string matuyen { get; set; }

        [StringLength(50)]
        public string tentuyen { get; set; }

        [StringLength(50)]
        public string diemdi { get; set; }

        [StringLength(50)]
        public string diemden { get; set; }

        public double? banggia { get; set; }

        [StringLength(300)]
        public string image { get; set; }

        public double? thoigian { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chuyenxe> chuyenxes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chuyenxe> chuyenxes1 { get; set; }
    }
}
