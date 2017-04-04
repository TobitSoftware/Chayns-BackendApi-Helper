using System.Net.Http;
using System.Threading.Tasks;
using Chayns.Backend.Api.Controller.Base;
using Chayns.Backend.Api.Credentials.Base;
using Chayns.Backend.Api.Models.Data;
using Chayns.Backend.Api.Models.Result;

namespace Chayns.Backend.Api.Controller
{
    /// <summary>
    /// Object to get, modify, create and delete uac groups
    /// </summary>
    public class UacController : BaseApiController<UacGroupResult>
    {
        /// <summary>
        /// Creates a new object to get, modify, create and delete uac groups
        /// </summary>
        public UacController() : base(null) { }
        /// <summary>
        /// Creates a new object to get, modify, create and delete uac groups
        /// </summary>
        /// <param name="credentials">Sets the credentials to authenticate all calling requests within this object</param>
        public UacController(ICredentials credentials) : base(credentials)
        {
        }

        /// <summary>
        /// Gets all uac groups async
        /// </summary>
        /// <param name="data">Filter for the request</param>
        /// <returns>A status and all uac groups matching the filter</returns>
        public async Task<Result<UacGroupResult>> GetUacGroupsAsync(UacGroupDataGet data)
        {
            return await Caller.CallApiAsync(data, this, HttpMethod.Get);
        }

        /// <summary>
        /// Gets all uac groups
        /// </summary>
        /// <param name="data">Filter for the request</param>
        /// <returns>A status and all uac groups matching the filter</returns>
        public Result<UacGroupResult> GetUacGroups(UacGroupDataGet data)
        {
            return Caller.CallApi(data, this, HttpMethod.Get);
        }

        /// <summary>
        /// Gets a uac group async
        /// </summary>
        /// <param name="uacGroupId">ID</param>
        /// <param name="location">Location</param>
        /// <returns>A status and the uac group matching the filter</returns>
        public async Task<SingleResult<UacGroupResult>> GetUacGroupAsync(int uacGroupId, LocationIdentifier location)
        {
            return await Caller.CallApiAsync(location, this, HttpMethod.Get, uacGroupId);
        }

        /// <summary>
        /// Gets a uac group
        /// </summary>
        /// <param name="uacGroupId">ID</param>
        /// <param name="location">Location</param>
        /// <returns>A status and the uac group matching the filter</returns>
        public SingleResult<UacGroupResult> GetUacGroup(int uacGroupId, LocationIdentifier location)
        {
            return Caller.CallApi(location, this, HttpMethod.Get, uacGroupId);
        }

        /// <summary>
        /// Adds a uac group async
        /// </summary>
        /// <param name="data">uac group description</param>
        /// <returns>The inserted uac group and the status</returns>
        public async Task<SingleResult<UacGroupResult>> AddUacGroupAsync(UacGroupDataAdd data)
        {
            return await Caller.CallApiAsync(data, this, HttpMethod.Post);
        }

        /// <summary>
        /// Adds a uac group
        /// </summary>
        /// <param name="data">uac group description</param>
        /// <returns>The inserted uac group and the status</returns>
        public SingleResult<UacGroupResult> AddUacGroup(UacGroupDataAdd data)
        {
            return Caller.CallApi(data, this, HttpMethod.Post);
        }

        /// <summary>
        /// Modifys a uac group async
        /// </summary>
        /// <param name="data">uac group description</param>
        /// <returns>The modified uac group and the status</returns>
        public async Task<SingleResult<UacGroupResult>> ChangeUacGroupAsync(UacGroupDataChange data)
        {
            return await Caller.CallApiAsync(data, this, new HttpMethod("PATCH"), data.UacGroupId);
        }

        /// <summary>
        /// Modifys a uac group
        /// </summary>
        /// <param name="data">uac group description</param>
        /// <returns>The modified uac group and the status</returns>
        public SingleResult<UacGroupResult> ChangeUacGroup(UacGroupDataChange data)
        {
            return Caller.CallApi(data, this, new HttpMethod("PATCH"), data.UacGroupId);
        }

        /// <summary>
        /// Deletes a uac group async
        /// </summary>
        /// <param name="data">uac group description</param>
        /// <returns>A status wheter the uac group was deleted or not</returns>
        public async Task<Status> RemoveUacGroupAsync(UacGroupDataRemove data)
        {
            return (await Caller.CallApiAsync(data, this, HttpMethod.Delete, data.UacGroupId))?.Status;
        }

        /// <summary>
        /// Deletes a uac group
        /// </summary>
        /// <param name="data">uac group description</param>
        /// <returns>A status wheter the uac group was deleted or not</returns>
        public Status RemoveUacGroup(UacGroupDataRemove data)
        {
            return Caller.CallApi(data, this, HttpMethod.Delete, data.UacGroupId)?.Status;
        }

        /// <summary>
        /// Gets the controllername for the WebApi
        /// </summary>
        /// <param name="caller">Calling function</param>
        /// <returns>Controllername for the WebApi</returns>
        public override string Controller(string caller)
        {
            return "Uac";
        }
    }
}
