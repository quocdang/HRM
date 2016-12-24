namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SALARY")]
    public partial class SALARY
    {
        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(20)]
        public string EmployeeID { get; set; }

        public int? WorkDays { get; set; }

        [StringLength(10)]
        public string Allowance { get; set; }

        [StringLength(10)]
        public string Deducttion { get; set; }

        [Column(TypeName = "money")]
        public decimal? RealSalary { get; set; }
    }
}
