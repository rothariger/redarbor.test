using Redarbor.Test.Commands.Commands;
using Redarbor.Test.DA;
using Redarbor.Test.Domain;

namespace Redarbor.Test.Commands
{
    public class CandidateCommandHandler
    {
        private readonly RedarborContext _context;

        public CandidateCommandHandler(RedarborContext context)
        {
            _context = context;
        }

        public async Task Handle(AddCandidateCommand command)
        {
            var candidate = new Candidates
            {
                Name = command.Name,
                Surname = command.Surname,
                Birthdate = command.Birthdate.Value,
                Email = command.Email,
                InsertDate = DateTime.Now
            };
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();
        }
    }

}