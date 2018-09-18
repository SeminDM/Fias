using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace DatabaseAPI.Models
{
    public class Developer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "tinyint")]
        public int? Age { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [DefaultValue("Unknown name")]
        public string FullName { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Email { get; set; }

        [Column(TypeName = "datetimeoffset")]
        public DateTimeOffset? BirthDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? GraduationDate { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan? WakeTime { get; set; }

        [Column(TypeName = "bit")]
        public bool? IsBackendDeveloper { get; set; }

        [Column(TypeName = "money")]
        public decimal? Salary { get; set; }

        [Column(TypeName = "image")]
        public string Avatar { get; set; }

        [ForeignKey("TeamMateId")]
        public List<Developer> TeamMates { get; set; }

        [ForeignKey("TeamLeadId")]
        public Developer TeamLead { get; set; }

        [NotMapped]
        [Column(TypeName = "timestamp")]
        public byte[] RowVersion { get; set; }
    }
}
