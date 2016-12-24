namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ALLOWANCE")]
    public partial class ALLOWANCE
    {
        [Key]
        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal? Money { get; set; }

        [StringLength(50)]
        public string Descr { get; set; }
    }
}
