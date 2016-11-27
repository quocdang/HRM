namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REWARD")]
    public partial class REWARD
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string RewardName { get; set; }

        [StringLength(20)]
        public string EmployeeID { get; set; }

        public DateTime? DecideDate { get; set; }

        [StringLength(10)]
        public string DecideNum { get; set; }
    }
}
