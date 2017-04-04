namespace Chayns.Backend.Api.Credentials.Base
{
    /// <summary>
    /// Interface to describe the credentials
    /// </summary>
    public interface ICredentials
    {
        /// <summary>
        /// Credentials scheme
        /// </summary>
        /// <returns></returns>
        string Scheme();

        /// <summary>
        /// Credentials parameter like access token, secret etc.
        /// </summary>
        /// <returns></returns>
        string Parameter();
    }
}
