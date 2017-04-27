using System;
using System.Collections.Generic;
using System.Linq;
using Chayns.Backend.Api.Controller;
using Chayns.Backend.Api.Credentials;
using Chayns.Backend.Api.Models.Data;
using Chayns.Backend.Api.Models.Result;
using Chayns.Backend.Extensions.Helper;
using Chayns.Backend.Extensions.Models;
using Chayns.Backend.Extensions.Models.Interfaces;

namespace Chayns.Backend.Extensions.AuthenticationAndAuthorization
{
    /// <summary>
    /// Represents the current (request-) user identity
    /// </summary>
    public class ChaynsUserIdenty : IChaynsIdentity
    {
        public ChaynsUserIdenty(string tobitAccessToken, IEnumerable<int>  requiredUacGroups = null)
        {
            AccessToken = tobitAccessToken;
            var tokenPayload = JwtHelper.GetPayload<UserAccessTokenPayload>(AccessToken);

            if (tokenPayload == null)
            {
                IsAuthenticated = false;
                return;
            }

            if (tokenPayload.ExpirationTime < DateTime.Now)
            {
                IsAuthenticated = false;
                return;
            }

            var tokenController = new AccessTokenController();
            var tokenCredentials = new AccessTokenCredentials(AccessToken);
            var dataGet = new UserAccessTokenDataGet(tokenPayload.LocationId, requiredUacGroups?.ToArray());

            var result = tokenController.GetUserAccessTokenInfo(tokenCredentials, dataGet);

            if (result.Status.StatusCode != 200)
            {
                IsAuthenticated = false;
                return;
            }

            ChaynsLogin = result.Data;

            if (ChaynsLogin == null)
            {
                IsAuthenticated = false;
                return;
            }

            if (result.Status.Success)
            {
                IsAuthenticated = true;
            }
        }

        public UserAccessTokenInfoResult ChaynsLogin { get; }

        /// <summary>
        ///     Gets the name of the current user.
        /// </summary>
        /// <returns>
        ///     The name of the user on whose behalf the code is running.
        /// </returns>
        public string Name
        {
            get
            {
                if (ChaynsLogin != null)
                    return ChaynsLogin.FirstName + " " + ChaynsLogin.LastName;

                return null;
            }
        }

        /// <summary>
        ///     Gets the type of authentication used.
        /// </summary>
        /// <returns>
        ///     The type of authentication used to identify the user.
        /// </returns>
        public string AuthenticationType => Config.TobitAccessToken;

        /// <summary>
        ///     Gets a value that indicates whether the user has been authenticated.
        /// </summary>
        /// <returns>
        ///     true if the user was authenticated; otherwise, false.
        /// </returns>
        public bool IsAuthenticated { get; }
        public string AccessToken { get; }
    }
}
