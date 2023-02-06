using Microsoft.EntityFrameworkCore;
using Redarbor.Test.DA;
using Redarbor.Test.Domain;
using Redarbor.Test.Queries.Queries;

namespace Redarbor.Test.Queries
{
    public class CandidateQueriesHandler
    {
        private readonly RedarborContext _dbContext;

        public CandidateQueriesHandler(RedarborContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Candidates>> Handle(GetAllCandidates _)
        {
            return await _dbContext.Set<Candidates>()
                .Include(p => p.CandidateExperiences)
                .ToListAsync();
        }

        public async Task<Candidates> Handle(GetCandidateById query)
        {
            return await _dbContext.Set<Candidates>()
                .Include(p => p.CandidateExperiences)
                .FirstOrDefaultAsync(f => f.IdCandidate.Equals(query.Id));
        }
    }
}