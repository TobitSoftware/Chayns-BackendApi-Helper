namespace Chayns.Backend.Api.Models.Data.Base
{
    /// <summary>
    /// Interface to describe the request data
    /// </summary>
    public interface IApiData
    {
        /// <summary>
        /// Gets the location identifier (LocationId or SiteId)
        /// </summary>
        /// <returns>LocationId or SiteId</returns>
        string GetLocationIdentifier();
    }
}
