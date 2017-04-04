using System;

namespace Chayns.Backend.Api.Models.Data.Base
{
    /// <summary>
    /// Baseclass of some requests
    /// </summary>
    public abstract class DefaultData:ChangeableData, IApiData
    {
        /// <summary>
        /// Sets the location identifier Locationid
        /// </summary>
        /// <param name="locationId"></param>
        protected DefaultData(int locationId)
        {
            LocationId = locationId;
            
        }

        /// <summary>
        /// Sets the location identifier SiteId
        /// </summary>
        /// <param name="siteId"></param>
        protected DefaultData(string siteId)
        {
            SiteId = siteId;
        }

        protected readonly int LocationId;

        protected readonly string SiteId;

        /// <summary>
        /// Gets the location identifier (LocationId or SiteId)
        /// </summary>
        /// <returns>LocationId or SiteId</returns>
        public string GetLocationIdentifier()
        {
            if (LocationId == 0)
            {
                if (string.IsNullOrWhiteSpace(SiteId))
                {
                    return "0";
                }
                else
                {
                    return SiteId;
                }
            }
            else
            {
                return Convert.ToString(LocationId);
            }
        }
    }
}
