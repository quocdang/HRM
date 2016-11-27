namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SALARY_ADVANCE
    {
        [Key]
        [StringLength(20)]
        public string SalaryAdvanceCode { get; set; }

        [StringLength(20)]
        public string EmployeeID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Money { get; set; }

        public string Reason { get; set; }
    }
}
