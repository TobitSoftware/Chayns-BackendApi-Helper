using System.Collections.Generic;
using Chayns.Backend.Api.Models.Data.Base;

namespace Chayns.Backend.Api.Models.Data
{
    public class PushData : DefaultData
    {
        public PushData(int locationId) : base(locationId)
        {
        }

        public PushData(string siteId) : base(siteId)
        {
        }

        #region UserId
        private int _userId;
        [Newtonsoft.Json.JsonProperty(PropertyName = "UserId")]
        internal int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
                OnPropertyChanged();
            }
        }
        #endregion UserId
        #region UacGroupId
        private int _uacGroupId;
        [Newtonsoft.Json.JsonProperty(PropertyName = "UacGroupId")]
        internal int UacGroupId
        {
            get
            {
                return _uacGroupId;
            }
            set
            {
                _uacGroupId = value;
                OnPropertyChanged();
            }
        }
        #endregion UacGroupId
        #region Alert
        private string _alert;
        public string Alert
        {
            get
            {
                return _alert;
            }
            set
            {
                _alert = value;
                OnPropertyChanged();
            }
        }
        #endregion Alert
        #region Actions

        private int _categoryId;
        private List<PushAction> _actions;

        public int CategoryId
        {
            get { return _categoryId; }
            set
            {
                _categoryId = value;
                OnPropertyChanged();
            }
        }

        public List<PushAction> Actions
        {
            get { return _actions; }
            set
            {
                _actions = value;
                OnPropertyChanged();
            }
        }

        #endregion Actions
        #region TappId
        private int? _tappId;

        public int? TappId
        {
            get
            {
                return _tappId;
            }
            set
            {
                _tappId = value;
                OnPropertyChanged();
            }
        }
        #endregion TappId

        #region Payload
        private Dictionary<string, object> _payload;

        public Dictionary<string, object> Payload
        {
            get { return _payload; }
            set
            {
                _payload = value;
                OnPropertyChanged();
            }
        }

        #endregion Payload
    }
}
