using System.Collections.Generic;
using System.Web;
using Chayns.Backend.Api.Credentials.Base;
using Chayns.Backend.Api.Models.Data;
using Chayns.Backend.Api.Models.Result;
using Chayns.Backend.Extensions.Models;
using Chayns.Backend.Extensions.Models.Interfaces;

namespace Chayns.Backend.Extensions.Helper
{
    /// <summary>
    /// Helper to get user informations from the request. The <see cref="Filter.TobitAccessTokenAuthentication"/> is requered.
    /// </summary>
    public static class IdentityHelper
    {
        /// <summary>
        /// Parses the accesstoken from the request context or return null if the token is invalid
        /// </summary>
        /// <returns></returns>
        public static UserAccessTokenPayload GetUserAccessTokenInfo()
        {
            var identity = HttpContext.Current?.User?.Identity as IChaynsIdentity;
            if (!(identity?.IsAuthenticated ?? false)) return null;

            var tokenPayload = JwtHelper.GetPayload<UserAccessTokenPayload>(identity.AccessToken);

            return tokenPayload;
        }

        /// <summary>
        /// Returns the current authentification type
        /// </summary>
        /// <returns></returns>
        public static string GetAuthenticationType()
        {
            return HttpContext.Current?.User?.Identity.AuthenticationType;
        }

        /// <summary>
        /// Requets the UAC groups of the current user from the BackendApi
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public static List<UacGroupResult> GetUacGroups(ICredentials credentials)
        {
            var ident = GetUserAccessTokenInfo();
            if (ident?.LocationId == null) return null;

            var uacDataGet = new UacGroupDataGet(ident.LocationId)
            {
                UserId = ident.UserId
            };
            var uacController = new Api.Controller.UacController(credentials);
            var uacResult = uacController.GetUacGroups(uacDataGet);

            return uacResult.Data;
        }
    }
}
