using System.Net.Http;
using System.Threading.Tasks;
using Chayns.Backend.Api.Controller.Base;
using Chayns.Backend.Api.Credentials.Base;
using Chayns.Backend.Api.Models.Data;
using Chayns.Backend.Api.Models.Result;

namespace Chayns.Backend.Api.Controller
{
    /// <summary>
    /// Object to push messages
    /// </summary>
    public class PushController : BaseApiController<PushResult>
    {
        /// <summary>
        /// Creates a new object to push messages
        /// </summary>
        public PushController() : base(null) { }
        /// <summary>
        /// Creates a new object to push messages
        /// </summary>
        /// <param name="credentials">Sets the credentials to authenticate all calling requests within this object</param>
        public PushController(ICredentials credentials) : base(credentials) { }

        /// <summary>
        /// Pushs a message to a user async
        /// </summary>
        /// <param name="userId">ID</param>
        /// <param name="data">Data to push</param>
        /// <returns>Status wheter the push was succesful or not</returns>
        public async Task<Status> PushToUserAsync(int userId, PushData data)
        {
            data.UserId = userId;
            return (await Caller.CallApiAsync(data, this, HttpMethod.Post))?.Status;
        }

        /// <summary>
        /// Pushs a message to a user
        /// </summary>
        /// <param name="userId">ID</param>
        /// <param name="data">Data to push</param>
        /// <returns>Status wheter the push was succesful or not</returns>
        public Status PushToUser(int userId, PushData data)
        {
            data.UserId = userId;
            return Caller.CallApi(data, this, HttpMethod.Post)?.Status;
        }

        /// <summary>
        /// Pushs a message to all users from a location async
        /// </summary>
        /// <param name="data">Data to push</param>
        /// <returns>Status wheter the push was succesful or not</returns>
        public async Task<Status> PushToLocationAsync(PushData data)
        {
            return (await Caller.CallApiAsync(data, this, HttpMethod.Post))?.Status;
        }

        /// <summary>
        /// Pushs a message to all users from a location
        /// </summary>
        /// <param name="data">Data to push</param>
        /// <returns>Status wheter the push was succesful or not</returns>
        public Status PushToLocation(PushData data)
        {
            return Caller.CallApi(data, this, HttpMethod.Post)?.Status;
        }

        /// <summary>
        /// Pushs a message to all users from a uac group async
        /// </summary>
        /// <param name="uacGroupId">ID</param>
        /// <param name="data">Data to push</param>
        /// <returns>Status wheter the push was succesful or not</returns>
        public async Task<Status> PushToUacGroupAsync(int uacGroupId, PushData data)
        {
            data.UacGroupId = uacGroupId;
            return (await Caller.CallApiAsync(data, this, HttpMethod.Post))?.Status;
        }

        /// <summary>
        /// Pushs a message to all users from a uac group
        /// </summary>
        /// <param name="uacGroupId">ID</param>
        /// <param name="data">Data to push</param>
        /// <returns>Status wheter the push was succesful or not</returns>
        public Status PushToUacGroup(int uacGroupId, PushData data)
        {
            data.UacGroupId = uacGroupId;
            return Caller.CallApi(data, this, HttpMethod.Post)?.Status;
        }

        /// <summary>
        /// Gets the controllername for the WebApi
        /// </summary>
        /// <param name="caller">Calling function</param>
        /// <returns>Controllername for the WebApi</returns>
        public override string Controller(string caller)
        {
            return "Push";
        }
    }
}
