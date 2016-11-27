namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPARTMENT")]
    public partial class DEPARTMENT
    {
        

        [Key]
        [StringLength(10)]
        public string DeptID { get; set; }

        [StringLength(100)]
        public string DeptName { get; set; }

        [StringLength(200)]
        public string Descr { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

    }
}
