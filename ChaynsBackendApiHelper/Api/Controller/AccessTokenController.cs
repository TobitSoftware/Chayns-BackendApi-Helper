using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading.Tasks;
using Chayns.Backend.Api.Controller.Base;
using Chayns.Backend.Api.Credentials;
using Chayns.Backend.Api.Credentials.Base;
using Chayns.Backend.Api.Models.Data;
using Chayns.Backend.Api.Models.Data.Base;
using Chayns.Backend.Api.Models.Result;
// ReSharper disable ExplicitCallerInfoArgument

namespace Chayns.Backend.Api.Controller
{
    /// <summary>
    /// Object to validate and get AccessTokens
    /// </summary>
    public class AccessTokenController : IApiController
    {
        private readonly ConcurrentDictionary<string, ICredentials> _credentials = new ConcurrentDictionary<string, ICredentials>();

        private WebApiCaller<PageAccessTokenInfoResult> _privPageCaller = null;
        private WebApiCaller<UserAccessTokenInfoResult> _privUserCaller = null;
        private WebApiCaller<ApiAccessTokenInfoResult> _privApiCaller = null;
        private WebApiCaller<PageAccessTokenResult> _privPagePostCaller = null;
        private WebApiCaller<PageAccessTokenInfoResult> PageCaller => _privPageCaller ?? (_privPageCaller = new WebApiCaller<PageAccessTokenInfoResult>());
        private WebApiCaller<UserAccessTokenInfoResult> UserCaller => _privUserCaller ?? (_privUserCaller = new WebApiCaller<UserAccessTokenInfoResult>());
        private WebApiCaller<ApiAccessTokenInfoResult> ApiCaller => _privApiCaller ?? (_privApiCaller = new WebApiCaller<ApiAccessTokenInfoResult>());
        private WebApiCaller<PageAccessTokenResult> PagePostCaller => _privPagePostCaller ?? (_privPagePostCaller = new WebApiCaller<PageAccessTokenResult>());


        /// <summary>
        /// Validates PageAccessToken async
        /// </summary>
        /// <param name="credentials">PageAccessToken to validate</param>
        /// <param name="req">Identifies the location</param>
        /// <returns>Info about given PageAccessToken</returns>
        public async Task<SingleResult<PageAccessTokenInfoResult>> GetPageAccessTokenInfoAsync(LocationIdentifier req, AccessTokenCredentials credentials)
        {
            Guid id = Guid.NewGuid();
            _credentials.TryAdd("GetPageAccessTokenInfoAsync" + id, credentials);
            return await PageCaller.CallApiAsync<DefaultData>(req, this, HttpMethod.Get, callingFunction: "GetPageAccessTokenInfoAsync" + id);
        }

        /// <summary>
        /// Validates PageAccessToken
        /// </summary>
        /// <param name="credentials">PageAccessToken to validate</param>
        /// <param name="req">Identifies the location</param>
        /// <returns>Info about given PageAccessToken</returns>
        public SingleResult<PageAccessTokenInfoResult> GetPageAccessTokenInfo(LocationIdentifier req, AccessTokenCredentials credentials)
        {
            Guid id = Guid.NewGuid();
            _credentials.TryAdd("GetPageAccessTokenInfo" + id, credentials);
            return PageCaller.CallApi<DefaultData>(req, this, HttpMethod.Get, callingFunction: "GetPageAccessTokenInfo" + id);
        }

        /// <summary>
        /// Validates UserAccessToken async
        /// </summary>
        /// <param name="credentials">UserAccessToken to validate</param>
        /// <param name="req">Identifies the location</param>
        /// <returns>Info about given UserAccessToken</returns>
        public async Task<SingleResult<UserAccessTokenInfoResult>> GetUserAccessTokenInfoAsync(LocationIdentifier req, AccessTokenCredentials credentials)
        {
            Guid id = Guid.NewGuid();
            _credentials.TryAdd("GetUserAccessTokenInfoAsync" + id, credentials);
            return await UserCaller.CallApiAsync<DefaultData>(req, this, HttpMethod.Get, callingFunction: "GetUserAccessTokenInfoAsync" + id);
        }

        /// <summary>
        /// Validates UserAccessToken
        /// </summary>
        /// <param name="credentials">UserAccessToken to validate</param>
        /// <param name="req">Identifies the location</param>
        /// <returns>Info about given UserAccessToken</returns>
        public SingleResult<UserAccessTokenInfoResult> GetUserAccessTokenInfo(LocationIdentifier req, AccessTokenCredentials credentials)
        {
            Guid id = Guid.NewGuid();
            _credentials.TryAdd("GetUserAccessTokenInfo" + id, credentials);
            return UserCaller.CallApi<DefaultData>(req, this, HttpMethod.Get, callingFunction: "GetUserAccessTokenInfo" + id);
        }

        /// <summary>
        /// Validates ApiAccessToken async
        /// </summary>
        /// <param name="credentials">ApiAccessToken to validate</param>
        /// <param name="req">Identifies the location</param>
        /// <returns>Info about given ApiAccessToken</returns>
        public async Task<SingleResult<ApiAccessTokenInfoResult>> GetApiAccessTokenInfoAsync(LocationIdentifier req, AccessTokenCredentials credentials)
        {
            Guid id = Guid.NewGuid();
            _credentials.TryAdd("GetApiAccessTokenInfoAsync" + id, credentials);
            return await ApiCaller.CallApiAsync<DefaultData>(req, this, HttpMethod.Get, callingFunction: "GetApiAccessTokenInfoAsync" + id);
        }

        /// <summary>
        /// Validates ApiAccessToken
        /// </summary>
        /// <param name="credentials">ApiAccessToken to validate</param>
        /// <param name="req">Identifies the location</param>
        /// <returns>Info about given ApiAccessToken</returns>
        public SingleResult<ApiAccessTokenInfoResult> GetApiAccessTokenInfo(LocationIdentifier req, AccessTokenCredentials credentials)
        {
            Guid id = Guid.NewGuid();
            _credentials.TryAdd("GetApiAccessTokenInfo" + id, credentials);
            return ApiCaller.CallApi<DefaultData>(req, this, HttpMethod.Get, callingFunction: "GetApiAccessTokenInfo" + id);
        }

        /// <summary>
        /// Creates new PageAccessToken async
        /// </summary>
        /// <param name="credentials">SecretCredentials to create new PageAccessToken for</param>
        /// <param name="data"></param>
        /// <returns> New PageAccessToken</returns>
        public async Task<SingleResult<PageAccessTokenResult>> GetPageAccessTokenAsync(SecretCredentials credentials, PageAccessTokenDataGet data)
        {
            Guid id = Guid.NewGuid();
            _credentials.TryAdd("GetPageAccessTokenAsync" + id, credentials);
            return await PagePostCaller.CallApiAsync(data, this, HttpMethod.Post, callingFunction: "GetPageAccessTokenAsync" + id);
        }

        /// <summary>
        /// Creates new PageAccessToken
        /// </summary>
        /// <param name="credentials">SecretCredentials to create new PageAccessToken for</param>
        /// <param name="data"></param>
        /// <returns> New PageAccessToken</returns>
        public SingleResult<PageAccessTokenResult> GetPageAccessToken(SecretCredentials credentials, PageAccessTokenDataGet data)
        {
            Guid id = Guid.NewGuid();
            _credentials.TryAdd("GetPageAccessToken" + id, credentials);
            return PagePostCaller.CallApi(data, this, HttpMethod.Post, callingFunction: "GetPageAccessToken" + id);
        }

        /// <summary>
        /// Gets the controllername for the WebApi
        /// </summary>
        /// <param name="caller">Calling function</param>
        /// <returns>Controllername for the WebApi</returns>
        public string Controller(string caller)
        {
            return "AccessToken";
        }

        /// <summary>
        /// Gets the credentials for the request
        /// </summary>
        /// <param name="caller">Calling function</param>
        /// <returns>Credentials for the request</returns>
        public ICredentials GetCredentials(string caller)
        {
            ICredentials credentials;
            _credentials.TryRemove(caller, out credentials);
            return credentials;
        }

        /// <summary>
        /// Sets the credentials for the request
        /// </summary>
        /// <param name="credentials">Credentials to set</param>
        public void SetCredentials(ICredentials credentials)
        {
            throw new MethodAccessException("Not allowed to use this method");
        }
    }
}
