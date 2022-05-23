namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("taixe")]
    public partial class taixe
    {
        [Key]
        [StringLength(10)]
        public string mataixe { get; set; }

        [StringLength(50)]
        public string tentaixe { get; set; }

        [StringLength(100)]
        public string diachi { get; set; }

        [StringLength(3)]
        public string gioitinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysinh { get; set; }

        [StringLength(10)]
        public string cmnd { get; set; }

        [StringLength(10)]
        public string sdt { get; set; }

        [StringLength(50)]
        public string email { get; set; }
    }
}
