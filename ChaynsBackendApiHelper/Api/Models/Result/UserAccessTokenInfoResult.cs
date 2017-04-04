using System;
using System.Collections.Generic;
using Chayns.Backend.Api.Models.Result.Base;

namespace Chayns.Backend.Api.Models.Result
{
    public class UserAccessTokenInfoResult : IApiResult
    {
        public List<string> Permissions { get; set; }
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Expires { get; set; }
        public TokenType TokenType { get; set; }
        public int? LocationId { get; set; }
        public int? UserId { get; set; }
        public string FacebookUserId { get; set; }
    }
}
