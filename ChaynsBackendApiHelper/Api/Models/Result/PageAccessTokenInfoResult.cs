using System;
using System.Collections.Generic;
using Chayns.Backend.Api.Models.Result.Base;

namespace Chayns.Backend.Api.Models.Result
{
    public class PageAccessTokenInfoResult : IApiResult
    {

        public int DeveloperId { get; set; }
        public int TappId { get; set; }
        public int LocationId { get; set; }
        public List<string> Permissions { get; set; }
        public DateTime Expires { get; set; }
        public TokenType TokenType { get; set; }
    }
}
