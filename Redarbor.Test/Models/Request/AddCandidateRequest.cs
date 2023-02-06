namespace Redarbor.Test.Models.Request
{
    public class AddCandidateRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Email { get; set; }
    }
}
