using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Redarbor.Test.Domain
{
    public class Candidates
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidate { get; set; }

        [MaxLength(50)]
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [MaxLength(150)]
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Surname { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [MaxLength(250)]
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Email { get; set; }

        [Required]
        public DateTime InsertDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        [ForeignKey("IdCandidate")]
        public ICollection<CandidateExperiences> CandidateExperiences { get; set; }
    }
}