using System;
using Newtonsoft.Json;

namespace Chayns.Backend.Extensions.Models
{
    public class UserAccessTokenPayload
    {
        [JsonIgnore]
        private int _tobitUserIdValue;
        [JsonIgnore]
        private string _facebookUserIdValue;
        [JsonIgnore]
        private DateTime _expirationTimeValue;

        [JsonProperty("TobitUserId")]
        private int TobitUserId { set { _tobitUserIdValue = value; } }
        [JsonProperty("FacebookUserID")]
        private string FacebookUserId { set { _facebookUserIdValue = value; } }
        [JsonProperty("exp")]
        private DateTime Exp { set { _expirationTimeValue = value; } }

        public int LocationId { get; set; }
        public int UserId => _tobitUserIdValue;
        public string PersonId { get; set; }
        public string FacebookId => _facebookUserIdValue;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ExpirationTime => _expirationTimeValue;
    }
}
