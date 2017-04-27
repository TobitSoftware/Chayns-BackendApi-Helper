using System.Collections.Generic;
using System.Security.Principal;

namespace Chayns.Backend.Extensions.AuthenticationAndAuthorization
{
    /// <summary>
    /// Stores the request-user information
    /// </summary>
    public class TobitAccessToken : IPrincipal
    {
        private readonly ChaynsUserIdenty _chaynsUser;

        public TobitAccessToken(string tobitAccessToken, IEnumerable<int> requiredUacGroups = null)
        {
            _chaynsUser = new ChaynsUserIdenty(tobitAccessToken, requiredUacGroups);
        }

        public IIdentity Identity => _chaynsUser;

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}
