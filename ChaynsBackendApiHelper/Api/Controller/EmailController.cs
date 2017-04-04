using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Chayns.Backend.Api.Controller.Base;
using Chayns.Backend.Api.Credentials.Base;
using Chayns.Backend.Api.Models.Data;
using Chayns.Backend.Api.Models.Result;

namespace Chayns.Backend.Api.Controller
{
    public sealed class EmailController : BaseApiController<EmailResult>
    {
        /// <summary>
        /// Creates a new object to send Emails
        /// </summary>
        public EmailController() : base(null) { }

        /// <summary>
        /// Creates a new object to send Emails
        /// </summary>
        /// <param name="credentials"></param>
        public EmailController(ICredentials credentials) : base(credentials) { }

        /// <summary>
        /// Sends an Email to given receivers async
        /// </summary>
        /// <param name="data">Data for email</param>
        /// <returns></returns>
        public async Task<SingleResult<EmailResult>> SendEmailAsync(EmailData data)
        {
            return (await Caller.CallApiAsync(data, this, HttpMethod.Post));
        }

        /// <summary>
        /// Sends an Email to given receivers
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public SingleResult<EmailResult> SendEmail(EmailData data)
        {
            return Caller.CallApi(data, this, HttpMethod.Post);
        }

        /// <summary>
        /// Gets the controllername for the WebApi
        /// </summary>
        /// <param name="caller">Calling function</param>
        /// <returns>Controllername for the WebApi</returns>
        public override string Controller(string caller)
        {
            return "Email";
        }
    }
}
