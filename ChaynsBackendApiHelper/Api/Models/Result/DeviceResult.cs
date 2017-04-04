using Chayns.Backend.Api.Models.Result.Base;

namespace Chayns.Backend.Api.Models.Result
{
    public class DeviceResult : IApiResult
    {
        public int DeviceId { get; set; }
        public string UdId { get; set; }
        public string DeviceToken { get; set; }
        public string SysVersion { get; set; }
        public int AppVersion { get; set; }
        public string LastRequest { get; set; }
        public string SysName { get; set; }
    }
}
