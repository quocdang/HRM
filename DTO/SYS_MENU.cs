namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_MENU
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public int? ParentID { get; set; }

        public int? Level { get; set; }

        [StringLength(200)]
        public string NameEN { get; set; }
    }
}
