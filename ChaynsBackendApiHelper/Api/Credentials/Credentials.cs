using Chayns.Backend.Api.Credentials.Base;

namespace Chayns.Backend.Api.Credentials
{
    public static class Credentials
    {
        /// <summary>
        /// Default credentials used, when no credentials were set for the request
        /// </summary>
        public static ICredentials DefaultCredential { get; private set; }

        /// <summary>
        /// Sets a default credentials, used when no credentials were set for the request
        /// </summary>
        /// <param name="credentials">Default credentials</param>
        public static void Initialize(ICredentials credentials)
        {
            DefaultCredential = credentials;
        }
    }
}
