using System;
using Chayns.Backend.Api.Credentials.Base;

namespace Chayns.Backend.Api.Credentials
{
    /// <summary>
    /// Credentials to authenticate via secret
    /// </summary>
    public class SecretCredentials:ICredentials
    {
        /// <summary>
        /// Creates credentials with a secret
        /// </summary>
        public SecretCredentials(string secret, int tappId)
        {
            Secret = secret;
            TappId = tappId;
        }

        public SecretCredentials(Guid secret, int tappId)
        {
            Secret = secret.ToString();
            TappId = tappId;
        }

        /// <summary>
        /// Secret to authenticate
        /// </summary>
        private string Secret { get; }

        /// <summary>
        /// TappId to authenticate
        /// </summary>
        private int TappId { get; }

        /// <summary>
        /// Gets the authenticate scheme secret
        /// </summary>
        /// <returns>"Secret"</returns>
        public string Scheme()
        {
            return "Basic";
        }

        /// <summary>
        /// Gets the secret
        /// </summary>
        /// <returns>TappSecret</returns>
        public string Parameter()
        {
            string cred = Convert.ToString(TappId) + ":" + Secret;
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(cred);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
