using Chayns.Backend.Api.Models.Data.Base;

namespace Chayns.Backend.Api.Models.Data
{
    public class UacGroupDataAdd : DefaultData
    {
        public UacGroupDataAdd(int locationId) : base(locationId)
        {
        }

        public UacGroupDataAdd(string siteId) : base(siteId)
        {
        }

        #region Name
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        #endregion Name
        #region ShowName
        private string _showName;
        public string ShowName
        {
            get
            {
                return _showName;
            }
            set
            {
                _showName = value;
                OnPropertyChanged();
            }
        }
        #endregion ShowName
        #region Description
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        #endregion Description
    }
}
