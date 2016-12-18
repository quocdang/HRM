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
        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal? Money { get; set; }

        [StringLength(50)]
        public string Descr { get; set; }
    }
}
