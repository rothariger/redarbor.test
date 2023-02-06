using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redarbor.Test.Domain
{
    public class CandidateExperiences
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidateExperience { get; set; }

        [ForeignKey("Candidates")]
        public int IdCandidate { get; set; }

        [MaxLength(100)]
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Company { get; set; }

        [MaxLength(100)]
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Job { get; set; }

        [MaxLength(4000)]
        [Required]
        [Column(TypeName = "varchar(4000)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public string Salary { get; set; }

        [Required]
        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public DateTime InsertDate { get; set; }

        public DateTime ModifyDate { get; set; }


        public Candidates Candidate { get; set; }

    }
}
