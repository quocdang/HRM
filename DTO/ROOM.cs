namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROOM")]
    public partial class ROOM
    {
        [StringLength(10)]
        public string RoomID { get; set; }

        [StringLength(50)]
        public string RoomName { get; set; }

        [StringLength(10)]
        public string GroupID { get; set; }

        [StringLength(100)]
        public string Descr { get; set; }

        [StringLength(100)]
        public string Note { get; set; }
    }
}
