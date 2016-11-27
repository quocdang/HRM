namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRAINNING")]
    public partial class TRAINNING
    {
        public int ID { get; set; }

        [StringLength(20)]
        public string EmployeeID { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        [StringLength(50)]
        public string Place { get; set; }

        [StringLength(50)]
        public string Reason { get; set; }

        [StringLength(50)]
        public string Time { get; set; }

        [StringLength(100)]
        public string Descr { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        [StringLength(100)]
        public string Result { get; set; }
    }
}
