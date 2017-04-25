using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Chayns.Backend.Extensions.Models;

namespace Chayns.Backend.Extensions.ActionResult
{
    /// <summary>
    /// Model wich will be returned if a invalid token is provided
    /// </summary>
    public class AuthenticationFailureResult : IHttpActionResult
    {
        private readonly HttpStatusCode _code;
        public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request, HttpStatusCode code = HttpStatusCode.Unauthorized)
        {
            _code = code;
            ReasonPhrase = reasonPhrase;
            Request = request;
        }

        public string ReasonPhrase { get; }

        public HttpRequestMessage Request { get; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            var error = new Error
            {
                Message = ReasonPhrase,
                Code = 401
            };

            var resp = new Models.Response.ErrorResponse
            {
                Error = error
            };

            var response = Request.CreateResponse(_code, resp);

            response.ReasonPhrase = ReasonPhrase;
            response.RequestMessage = Request;

            return response;
        }
    }
}
