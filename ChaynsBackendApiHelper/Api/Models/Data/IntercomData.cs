﻿using System.Collections.Generic;
using Chayns.Backend.Api.Models.Data.Base;

namespace Chayns.Backend.Api.Models.Data
{
    public class IntercomData : CommunicationBaseData
    {
        public IntercomData(int locationId) : base(locationId)
        {
        }

        public IntercomData(string siteId) : base(siteId)
        {
        }

        #region ThreadName

        private string _threadName;

        [Newtonsoft.Json.JsonProperty(PropertyName = "ThreadName")]
        public string ThreadName
        {
            get { return _threadName; }
            set
            {
                _threadName = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region SendAsSystemMessage

        private bool _sendAsSystemMessage;

        [Newtonsoft.Json.JsonProperty(PropertyName = "SendAsSystemMessage")]
        public bool SendAsSystemMessage
        {
            get { return _sendAsSystemMessage; }
            set
            {
                _sendAsSystemMessage = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region UseGroupChat

        private bool _useGroupChat;
        [Newtonsoft.Json.JsonProperty(PropertyName = "UseGroupChat")]
        public bool UseGroupChat
        {
            get { return _useGroupChat; }
            set
            {
                _useGroupChat = value;
                OnPropertyChanged();
            }
        }

        #endregion UseGroupChat

        #region ReceiverLocationIds

        private List<int> _receiverLocationIds;
        [Newtonsoft.Json.JsonProperty(PropertyName = "ReceiverLocationIds")]
        public List<int> ReceiverLocationIds
        {
            get { return _receiverLocationIds; }
            set
            {
                _receiverLocationIds = value;
                OnPropertyChanged();
            }
        }

        #endregion ReceiverLocationIds

        #region Message

        private string _message;

        [Newtonsoft.Json.JsonProperty(PropertyName = "Message")]
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        #endregion Message

        #region UserAccessToken

        private string _userAccessToken;

        [Newtonsoft.Json.JsonProperty(PropertyName = "UserAccessToken")]
        public string UserAccessToken
        {
            get { return _userAccessToken; }
            set
            {
                _userAccessToken = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
