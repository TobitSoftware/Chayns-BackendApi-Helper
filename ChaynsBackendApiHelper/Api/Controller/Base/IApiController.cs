using Chayns.Backend.Api.Credentials.Base;

namespace Chayns.Backend.Api.Controller.Base
{
    public interface IApiController
    {
        /// <summary>
        /// Gets the controllername for the WebApi
        /// </summary>
        /// <param name="caller">Calling function</param>
        /// <returns>Controllername for the WebApi</returns>
        string Controller(string caller);

        /// <summary>
        /// Gets the credentials for the request
        /// </summary>
        /// <param name="caller">Calling function</param>
        /// <returns>Credentials for the request</returns>
        ICredentials GetCredentials(string caller);

        /// <summary>
        /// Sets the credentials for the request
        /// </summary>
        /// <param name="credentials">Credentials to set</param>
        void SetCredentials(ICredentials credentials);
    }
}
