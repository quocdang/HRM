namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CANDIDATE")]
    public partial class CANDIDATE
    {
        [Key]
        [StringLength(20)]
        public string CandidateCode { get; set; }

        [StringLength(20)]
        public string RecruitmentCode { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public bool? Gender { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(255)]
        public string BirthPlace { get; set; }

        [StringLength(255)]
        public string MainAddress { get; set; }

        [StringLength(255)]
        public string ContactAddress { get; set; }

        [StringLength(20)]
        public string CellPhone { get; set; }

        [StringLength(20)]
        public string HomePhone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        [StringLength(100)]
        public string Language { get; set; }

        [StringLength(100)]
        public string Education { get; set; }

        [StringLength(100)]
        public string Job { get; set; }

        [StringLength(255)]
        public string Experience { get; set; }

        [Column(TypeName = "money")]
        public decimal? ExpectSalary { get; set; }
    }
}
