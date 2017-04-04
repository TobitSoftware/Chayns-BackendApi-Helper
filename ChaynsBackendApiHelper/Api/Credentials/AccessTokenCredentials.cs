using Chayns.Backend.Api.Credentials.Base;

namespace Chayns.Backend.Api.Credentials
{
    /// <summary>
    /// Credentials to authenticate via access token
    /// </summary>
    public class AccessTokenCredentials : ICredentials
    {
        /// <summary>
        /// Creates credentials with a access token
        /// </summary>
        /// <param name="accessToken">Access token to authenticate</param>
        public AccessTokenCredentials(string accessToken)
        {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Access token to authenticate
        /// </summary>
        private string AccessToken { get; }

        /// <summary>
        /// Gets the authenticate scheme bearer
        /// </summary>
        /// <returns>Bearer</returns>
        public string Scheme()
        {
            return "Bearer";
        }

        /// <summary>
        /// Gets the access token
        /// </summary>
        /// <returns>Access token</returns>
        public string Parameter()
        {
            return AccessToken;
        }
    }
}
