using Chayns.Backend.Api.Models.Result.Base;

namespace Chayns.Backend.Api.Models.Result
{
    public class UserResult : IApiResult
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int CountGroups { get; set; }
        public string PersonId { get; set; }
        public string Picture { get; set; }
    }
}
