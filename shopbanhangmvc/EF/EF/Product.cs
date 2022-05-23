namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [StringLength(50)]
        public string id { get; set; }

        [Required]
        [StringLength(50)]
        public string brand { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(400)]
        public string picture { get; set; }

        [StringLength(300)]
        public string description { get; set; }

        [StringLength(100)]
        public string origin { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateExport { get; set; }

        public int status { get; set; }

        public int? price { get; set; }
    }
}
