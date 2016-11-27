namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTRACTTYPE")]
    public partial class CONTRACTTYPE
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string ContractName { get; set; }

        public int? Month { get; set; }
    }
}
