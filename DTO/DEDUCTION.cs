namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEDUCTION")]
    public partial class DEDUCTION
    {
        

        [Key]
        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? Rate { get; set; }

        [StringLength(50)]
        public string Descr { get; set; }
        
    }
}
