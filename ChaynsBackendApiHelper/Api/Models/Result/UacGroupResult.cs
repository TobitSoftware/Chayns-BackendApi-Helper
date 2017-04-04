using Chayns.Backend.Api.Models.Result.Base;

namespace Chayns.Backend.Api.Models.Result
{
    public class UacGroupResult : IApiResult
    {
        public int UserGroupId { get; set; }
        public string ShowName { get; set; }
        public string Name { get; set; }
        public int? TappId { get; set; }
        public int CountMember { get; set; }
    }
}
