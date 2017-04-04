using Chayns.Backend.Api.Models.Result.Base;

namespace Chayns.Backend.Api.Models.Result
{
    public class LocationResult : IApiResult
    {
        public int LocationId { get; set; }
        public string SiteId { get; set; }
        public string Name { get; set; }
        public string AppName { get; set; }
        public int AndroidAppVersion { get; set; }
        public int IosAppVersion { get; set; }
        public int CountMember { get; set; }
    }
}
