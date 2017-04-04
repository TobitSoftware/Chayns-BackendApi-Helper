using System;
using System.Collections.Generic;
using Chayns.Backend.Api.Models.Result.Base;

namespace Chayns.Backend.Api.Models.Result
{
    public class ApiAccessTokenInfoResult : IApiResult
    {
        public List<string> Permissions { get; set; }
        public DateTime Expires { get; set; }
        public TokenType TokenType { get; set; }
        public Dictionary<string, string> Data { get; set; }
    }
}
