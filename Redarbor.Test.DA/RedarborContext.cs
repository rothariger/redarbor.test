using Microsoft.EntityFrameworkCore;
using Redarbor.Test.Domain;

namespace Redarbor.Test.DA
{
    public class RedarborContext : DbContext
    {
        public RedarborContext(DbContextOptions<RedarborContext> options) : base(options)
        { }

        public DbSet<Candidates> Candidates { get; set; }
        public DbSet<CandidateExperiences> CandidateExperiences { get; set; }
    }
}