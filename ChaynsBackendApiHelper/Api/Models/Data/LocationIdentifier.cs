using Chayns.Backend.Api.Models.Data.Base;

namespace Chayns.Backend.Api.Models.Data
{
    public class LocationIdentifier:DefaultData
    {
        public LocationIdentifier(int locationId) : base(locationId)
        {
        }

        public LocationIdentifier(string siteId) : base(siteId)
        {
        }
    }
}
