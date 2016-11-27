namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DISCIPLINE")]
    public partial class DISCIPLINE
    {
        [Key]
        public int ID { get; set; }

        [StringLength(20)]
        public string EmployeeID { get; set; }

        public string Descr { get; set; }

        public DateTime? Date { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }
    }
}
