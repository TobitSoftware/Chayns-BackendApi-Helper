using Chayns.Backend.Api.Models.Data.Base;

namespace Chayns.Backend.Api.Models.Data
{
    public sealed class LocationDataGet : DefaultData
    {
        public LocationDataGet(int locationId):base(locationId) { }

        public LocationDataGet(string siteId):base(siteId) { }
    }
}
