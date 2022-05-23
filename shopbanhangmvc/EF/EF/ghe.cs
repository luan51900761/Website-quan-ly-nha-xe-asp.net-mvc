namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ghe")]
    public partial class ghe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ghe()
        {
            vexes = new HashSet<vexe>();
        }

        [Key]
        [StringLength(10)]
        public string tenghe { get; set; }

        public int? hang { get; set; }

        public int? tang { get; set; }

        public int? cot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vexe> vexes { get; set; }
    }
}
