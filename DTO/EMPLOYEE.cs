namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLOYEE")]
    public partial class EMPLOYEE
    {
        
        [Key]
        [StringLength(20)]
        public string EmployeeID { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime? DOB { get; set; }

        public string Address { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public bool? Gender { get; set; }

        [StringLength(10)]
        public string DeptID { get; set; }

        [StringLength(10)]
        public string RoomID { get; set; }

        [StringLength(10)]
        public string GroupID { get; set; }

        [StringLength(10)]
        public string PostionID { get; set; }

        public virtual GROUP GROUP { get; set; }

        public virtual POSITION POSITION { get; set; }

        public virtual ROOM ROOM { get; set; }
    }
}
