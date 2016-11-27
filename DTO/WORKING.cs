namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WORKING")]
    public partial class WORKING
    {
        [Key]
        public int ID { get; set; }

        [StringLength(20)]
        public string EmployeeID { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        [StringLength(10)]
        public string PositionID { get; set; }

        [StringLength(50)]
        public string Reason { get; set; }

        [StringLength(10)]
        public string DecideNum { get; set; }
        
    }
}
