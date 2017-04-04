using System.Net.Http;
using System.Threading.Tasks;
using Chayns.Backend.Api.Controller.Base;
using Chayns.Backend.Api.Credentials.Base;
using Chayns.Backend.Api.Models.Data;
using Chayns.Backend.Api.Models.Result;

namespace Chayns.Backend.Api.Controller
{
    public sealed class IntercomController: BaseApiController<IntercomResult>
    {
        /// <summary>
        /// Creates a new object to send Intercom messages
        /// </summary>
        public IntercomController() : base(null) { }
        /// <summary>
        /// Creates a new object to send Intercom messages
        /// </summary>
        /// <param name="credentials">Sets the credentials to authenticate all calling requests within this object</param>
        public IntercomController(ICredentials credentials) : base(credentials) { }

        /// <summary>
        /// Sends a message to given receivers async
        /// </summary>
        /// <param name="data">Data for Intercom messages</param>
        /// <returns>Status wheter the Intercom was succesful or not</returns>
        public async Task<SingleResult<IntercomResult>> SendIntercomMessageAsync(IntercomData data)
        {
            return (await Caller.CallApiAsync(data, this, HttpMethod.Post));
        }

        /// <summary>
        /// Sends a message to given receivers
        /// </summary>
        /// <param name="data">Data for Intercom messages</param>
        /// <returns>Status wheter the Intercom was succesful or not</returns>
        public SingleResult<IntercomResult> SendIntercomMessage(IntercomData data)
        {
            return Caller.CallApi(data, this, HttpMethod.Post);
        }


        /// <summary>
        /// Gets the controllername for the WebApi
        /// </summary>
        /// <param name="caller">Calling function</param>
        /// <returns>Controllername for the WebApi</returns>
        public override string Controller(string caller)
        {
            return "Intercom";
        }
    }
}
