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

        public TobitAccessToken(string tobitAccessToken, IEnumerable<int> requieredUacGroups = null)
        {
            _chaynsUser = new ChaynsUserIdenty(tobitAccessToken, requieredUacGroups);
        }

        public IIdentity Identity => _chaynsUser;

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}
