using System.Net.Http;
using System.Threading.Tasks;
using Chayns.Backend.Api.Controller.Base;
using Chayns.Backend.Api.Credentials.Base;
using Chayns.Backend.Api.Models.Data;
using Chayns.Backend.Api.Models.Result;

namespace Chayns.Backend.Api.Controller
{
    /// <summary>
    /// Object to get, add and delete uac members
    /// </summary>
    public class UacMemberController : BaseApiController<UacMemberResult>
    {
        /// <summary>
        /// Creates a new object to get, add and delete uac members
        /// </summary>
        public UacMemberController() : base(null) { }
        /// <summary>
        /// Creates a new object to get, add and delete uac members
        /// </summary>
        /// <param name="credentials">Sets the credentials to authenticate all calling requests within this object</param>
        public UacMemberController(ICredentials credentials) : base(credentials)
        {
        }

        /// <summary>
        /// Gets all uac members async
        /// </summary>
        /// <param name="data">Filter for the request</param>
        /// <returns>A status and all uac members matching the filter</returns>
        public async Task<Result<UacMemberResult>> GetUacGroupMemberAsync(UacMemberDataGet data)
        {
            return await Caller.CallApiAsync(data, this, HttpMethod.Get);
        }

        /// <summary>
        /// Gets all uac members
        /// </summary>
        /// <param name="data">Filter for the request</param>
        /// <returns>A status and all uac members matching the filter</returns>
        public Result<UacMemberResult> GetUacGroupMember(UacMemberDataGet data)
        {
            return Caller.CallApi(data, this, HttpMethod.Get);
        }

        /// <summary>
        /// Adds a uac member async
        /// </summary>
        /// <param name="data">User</param>
        /// <returns>The inserted uac member and the status</returns>
        public async Task<SingleResult<UacMemberResult>> AddUacGroupMemberAsync(UacMemberDataAdd data)
        {
            return await Caller.CallApiAsync(data, this, HttpMethod.Post);
        }

        /// <summary>
        /// Adds a uac member async
        /// </summary>
        /// <param name="data">User</param>
        /// <returns>The inserted uac member and the status</returns>
        public SingleResult<UacMemberResult> AddUacGroupMember(UacMemberDataAdd data)
        {
            return Caller.CallApi(data, this, HttpMethod.Post);
        }

        /// <summary>
        /// Removes a uac member async
        /// </summary>
        /// <param name="data">User</param>
        /// <returns>A status wheter the uac member was removed or not</returns>
        public async Task<Status> RemoveUacGroupMemberAsync(UacMemberDataDelete data)
        {
            return (await Caller.CallApiAsync(data, this, HttpMethod.Delete))?.Status;
        }

        /// <summary>
        /// Removes a uac member async
        /// </summary>
        /// <param name="data">User</param>
        /// <returns>A status wheter the uac member was removed or not</returns>
        public Status RemoveUacGroupMember(UacMemberDataDelete data)
        {
            return Caller.CallApi(data, this, HttpMethod.Delete)?.Status;
        }

        /// <summary>
        /// Gets the controllername for the WebApi
        /// </summary>
        /// <param name="caller">Calling function</param>
        /// <returns>Controllername for the WebApi</returns>
        public override string Controller(string caller)
        {
            return "UacMember";
        }
    }
}
