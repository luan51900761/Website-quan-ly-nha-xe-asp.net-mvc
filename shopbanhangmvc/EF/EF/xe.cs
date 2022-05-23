namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("xe")]
    public partial class xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public xe()
        {
            chuyenxes = new HashSet<chuyenxe>();
        }

        [Key]
        [StringLength(10)]
        public string maxe { get; set; }

        [StringLength(10)]
        public string tenxe { get; set; }

        [StringLength(10)]
        public string bienso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chuyenxe> chuyenxes { get; set; }
    }
}
