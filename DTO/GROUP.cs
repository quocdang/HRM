namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GROUP")]
    public partial class GROUP
    {
        [StringLength(10)]
        public string GroupID { get; set; }

        [StringLength(50)]
        public string GroupName { get; set; }

        [StringLength(10)]
        public string DeptID { get; set; }

        [StringLength(100)]
        public string Descr { get; set; }

        [StringLength(100)]
        public string Note { get; set; }
    }
}
