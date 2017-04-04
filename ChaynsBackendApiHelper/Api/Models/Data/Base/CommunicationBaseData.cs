using System.Collections.Generic;

namespace Chayns.Backend.Api.Models.Data.Base
{
    public class CommunicationBaseData : DefaultData
    {
        public CommunicationBaseData(int locationId) : base(locationId) { }

        public CommunicationBaseData(string siteId): base(siteId) { }

        #region UserIds
        private List<int> _userIds;
        [Newtonsoft.Json.JsonProperty(PropertyName = "UserIds")]
        public List<int> UserIds
        {
            get
            {
                return _userIds;
            }
            set
            {
                _userIds = value;
                OnPropertyChanged();
            }
        }
        #endregion UserIds

        #region UacIds

        private List<int> _uacIds;
        [Newtonsoft.Json.JsonProperty(PropertyName = "UacIds")]
        public List<int> UacIds
        {
            get { return _uacIds; }
            set
            {
                _uacIds = value;
                OnPropertyChanged();
            }
        }

        #endregion UacIds
        
    }
}
