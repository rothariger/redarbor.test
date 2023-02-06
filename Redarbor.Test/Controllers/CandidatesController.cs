using Converto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Redarbor.Test.Commands;
using Redarbor.Test.Commands.Commands;
using Redarbor.Test.Models.Request;
using Redarbor.Test.Models.Response;
using Redarbor.Test.Queries;
using Redarbor.Test.Queries.Queries;

namespace Redarbor.Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateCommandHandler _candidateCommandHandler;
        private readonly CandidateQueriesHandler _candidateQueryHandler;
        public CandidatesController(CandidateCommandHandler candidateCommandHandler,
            CandidateQueriesHandler candidateQueryHandler)
        {
            _candidateCommandHandler = candidateCommandHandler;
            _candidateQueryHandler = candidateQueryHandler;
        }

        [HttpGet]
        public async Task<IEnumerable<CandidatesResponse>> GetAll()
        {
            var query = new GetAllCandidates();
            var list = await _candidateQueryHandler.Handle(query);
            return list.Select(s => s.ConvertTo<CandidatesResponse>())
                .ToList();
        }

        [HttpPost]
        public async Task SaveCandidate([FromBody] AddCandidateRequest addCandidateRequest)
        {
            var command = addCandidateRequest.ConvertTo<AddCandidateCommand>();
            await _candidateCommandHandler.Handle(command);
        }

    }
}
