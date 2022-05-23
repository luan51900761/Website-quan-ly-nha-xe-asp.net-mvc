namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vexe")]
    public partial class vexe
    {
        [Key]
        public int mave { get; set; }

        public int? mahd { get; set; }

        [StringLength(10)]
        public string tenghe { get; set; }

        public int? tinhtrang { get; set; }

        public virtual ghe ghe { get; set; }

        public virtual hoadon hoadon { get; set; }
    }
}
