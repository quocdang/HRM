namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("POSITION")]
    public partial class POSITION
    {
        [StringLength(10)]
        public string PositionID { get; set; }

        [StringLength(50)]
        public string PositionName { get; set; }

        [StringLength(100)]
        public string Descr { get; set; }

        [StringLength(100)]
        public string Note { get; set; }
    }
}
