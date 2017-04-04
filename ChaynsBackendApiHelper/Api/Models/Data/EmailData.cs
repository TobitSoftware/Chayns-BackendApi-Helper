using Chayns.Backend.Api.Models.Data.Base;

namespace Chayns.Backend.Api.Models.Data
{
    public class EmailData : CommunicationBaseData
    {
        public EmailData(int locationId) : base(locationId) { }

        public EmailData(string siteId): base(siteId) { }

        #region Subject

        private string _subject;
        [Newtonsoft.Json.JsonProperty(PropertyName = "Subject")]
        public string Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                OnPropertyChanged();
            }
        }
        #endregion Subject
        #region headline

        private string _headline;
        [Newtonsoft.Json.JsonProperty(PropertyName = "Headline")]
        public string Headline
        {
            get { return _headline; }
            set
            {
                _headline = value;
                OnPropertyChanged();
            }
        }

        #endregion headline 
        #region text

        private string _text;
        [Newtonsoft.Json.JsonProperty(PropertyName = "Text")]
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
        #endregion text
        #region greeting

        private string _greeting;
        [Newtonsoft.Json.JsonProperty(PropertyName = "Greeting")]
        public string Greeting
        {
            get { return _greeting; }
            set
            {
                _greeting = value;
                OnPropertyChanged();
            }
        }

        #endregion greeting
    }
}
