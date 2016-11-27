namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EMP_ALLOWANCE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string EmployeeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string AllowanceCode { get; set; }
    }
}
