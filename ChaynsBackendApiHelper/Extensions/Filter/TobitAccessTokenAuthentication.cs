using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Chayns.Backend.Extensions.ActionResult;
using Chayns.Backend.Extensions.AuthenticationAndAuthorization;
using Chayns.Backend.Extensions.Helper;

namespace Chayns.Backend.Extensions.Filter
{
    public class TobitAccessTokenAuthentication : ActionFilterAttribute, IAuthenticationFilter
    {
        /// <summary>
        /// Defines if an access token is required or not
        /// </summary>
        public bool Optional = false;

        /// <summary>
        /// Definies the UAC groups wich are allowed to execute the request
        /// </summary>
        public string RequiredUacGroups
        {
            get { return $"{string.Join(",", _requiredUacGroupsList)}"; }
            set { _requiredUacGroupsList = Array.ConvertAll(value.Split(','), int.Parse).ToList(); }
        }

        private IEnumerable<int> _requiredUacGroupsList;

        public override bool AllowMultiple => false;

        /// <summary>
        /// Authenticates the user or throws a authentification-exception
        /// </summary>
        /// <param name="context">The current <see cref="HttpAuthenticationContext"/></param>
        /// <param name="cancellationToken">The current <see cref="CancellationToken"/> (From the current request)</param>
        /// <returns></returns>
#pragma warning disable 1998
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
#pragma warning restore 1998
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null && Optional)
            {
                return;
            }
            if (authorization == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Wrong authentication type", request, HttpStatusCode.BadRequest);
                return;
            }

            if (authorization.Scheme.ToLower() != "bearer") return;

            if (string.IsNullOrEmpty(authorization.Parameter) && !Optional)
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing TobitAccessToken", request);
                return;
            }

            var principal = Authenticate(authorization.Parameter, _requiredUacGroupsList);

            if (principal == null)
            {
                context.Principal = null;
                if (!Optional)
                {
                    context.ErrorResult = new AuthenticationFailureResult("Invalid TobitAccessToken", request);
                }
            }
            else
            {
                context.Principal = principal;
                if (!Optional && !principal.Identity.IsAuthenticated)
                {
                    context.ErrorResult = new AuthenticationFailureResult("Unauthorized", request);
                }
            }
        }

        /// <summary>
        /// Adds the <see cref="AddChallengeOnUnauthorizedResult"/> to the <see cref="HttpAuthenticationChallengeContext"/>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var challenge = new AuthenticationHeaderValue("Bearer");
            context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
            return Task.FromResult(0);
        }

        /// <summary>
        /// Requests the token payload from the BackendApi to authenticate the user
        /// </summary>
        /// <param name="tobitAccessToken"></param>
        /// <param name="requiredUacGroups"></param>
        /// <returns></returns>
        protected virtual TobitAccessToken Authenticate(string tobitAccessToken, IEnumerable<int> requiredUacGroups)
        {
            var valid = JwtHelper.IsValid(tobitAccessToken);
            return valid ? new TobitAccessToken(tobitAccessToken, requiredUacGroups) : null;
        }
    }
}
