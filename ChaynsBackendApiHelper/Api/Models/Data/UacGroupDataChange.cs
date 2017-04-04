using Chayns.Backend.Api.Models.Data.Base;

namespace Chayns.Backend.Api.Models.Data
{
    public class UacGroupDataChange : DefaultData
    {
        public UacGroupDataChange(int locationId) : base(locationId)
        {
        }

        public UacGroupDataChange(string siteId) : base(siteId)
        {
        }

        #region UacGroupId

        private int _uacGroupId;

        public int UacGroupId
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
    }
}
