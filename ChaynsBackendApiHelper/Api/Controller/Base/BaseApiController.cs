using Chayns.Backend.Api.Credentials.Base;
using Chayns.Backend.Api.Models.Result.Base;

namespace Chayns.Backend.Api.Controller.Base
{
    public abstract class BaseApiController<TResult> : IApiController where TResult: IApiResult
    {
        /// <summary>
        /// Constructs a BaseApiController
        /// </summary>
        /// <param name="credentials">Sets the credentials for all Request with this object</param>
        protected BaseApiController(ICredentials credentials)
        {
            SetCredentials(credentials);
            Caller = new WebApiCaller<TResult>();
        }
        /// <summary>
        /// Credentials to authenticat the request
        /// </summary>
        private ICredentials _credentials;
        /// <summary>
        /// Object to help calling the WebApi
        /// </summary>
        internal readonly WebApiCaller<TResult> Caller;

        /// <summary>
        /// Gets the controllername for the WebApi
        /// </summary>
        /// <param name="caller">Calling function</param>
        /// <returns>Controllername for the WebApi</returns>
        public abstract string Controller(string caller);

        /// <summary>
        /// Gets the credentials for the request
        /// </summary>
        /// <param name="caller">Calling function</param>
        /// <returns>Credentials for the request</returns>
        public ICredentials GetCredentials(string caller)
        {
            return _credentials?? Credentials.Credentials.DefaultCredential;
        }

        /// <summary>
        /// Sets the credentials for the request
        /// </summary>
        /// <param name="credentials">Credentials to set</param>
        public void SetCredentials(ICredentials credentials)
        {
            _credentials = credentials;
        }
    }
}
