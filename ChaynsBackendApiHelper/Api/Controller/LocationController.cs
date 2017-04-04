using System.Net.Http;
using System.Threading.Tasks;
using Chayns.Backend.Api.Controller.Base;
using Chayns.Backend.Api.Credentials.Base;
using Chayns.Backend.Api.Models.Data;
using Chayns.Backend.Api.Models.Result;

namespace Chayns.Backend.Api.Controller
{
    /// <summary>
    /// Object to get location data
    /// </summary>
    public sealed class LocationController : BaseApiController<LocationResult>
    {
        /// <summary>
        /// Creates a new object to get locations
        /// </summary>
        public LocationController() : base(null) { }
        /// <summary>
        /// Creates a new object to get locations
        /// </summary>
        /// <param name="credentials">Sets the credentials to authenticate all calling requests within this object</param>
        public LocationController(ICredentials credentials) : base(credentials) { }

        /// <summary>
        /// Gets all locations async
        /// </summary>
        /// <param name="data">Filter for the request</param>
        /// <returns>A status and all locations matching the filter</returns>
        public async Task<SingleResult<LocationResult>> GetLocationAsync(LocationDataGet data)
        {
            return await Caller.CallApiAsync(data, this, HttpMethod.Get);
        }

        /// <summary>
        /// Gets all locations
        /// </summary>
        /// <param name="data">Filter for the request</param>
        /// <returns>A status and all locations matching the filter</returns>
        public SingleResult<LocationResult> GetLocation(LocationDataGet data)
        {
            return Caller.CallApi(data, this, HttpMethod.Get);
        }

        /// <summary>
        /// Gets the controllername for the WebApi
        /// </summary>
        /// <param name="caller">Calling function</param>
        /// <returns>Controllername for the WebApi</returns>
        public override string Controller(string caller)
        {
            return "Location";
        }
    }
}
