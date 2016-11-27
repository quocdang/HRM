namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTRACT")]
    public partial class CONTRACT
    {
        [Key]
        [StringLength(20)]
        public string ContractCode { get; set; }

        public int? ContractType { get; set; }

        [StringLength(20)]
        public string EmployeeID { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? Salary { get; set; }

        public DateTime? SignDate { get; set; }

        public DateTime? ValidDate { get; set; }

    }
}
