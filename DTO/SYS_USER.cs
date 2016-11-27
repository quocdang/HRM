namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_USER
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(10)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        public int? UserGroup { get; set; }

        public bool? Active { get; set; }
    }
}
