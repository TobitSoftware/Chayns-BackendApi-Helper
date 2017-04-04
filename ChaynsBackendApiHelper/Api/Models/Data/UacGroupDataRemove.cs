using Chayns.Backend.Api.Models.Data.Base;

namespace Chayns.Backend.Api.Models.Data
{
    public class UacGroupDataRemove : DefaultData
    {
        public UacGroupDataRemove(int locationId) : base(locationId)
        {
        }

        public UacGroupDataRemove(string siteId) : base(siteId)
        {
        }

        #region UacGroupId

        private int _uacGropId;

        public int UacGroupId
        {
            get
            {
                return _uacGropId; 
            }
            set
            {
                _uacGropId = value;
                OnPropertyChanged();
            }
        }

        #endregion UacGroupId

        #region ForceRemoveUacGroup
        private bool _forceRemoveUacGroup;

        public bool ForceRemoveUacGroup
        {
            get
            {
                return _forceRemoveUacGroup;
            }
            set
            {
                _forceRemoveUacGroup = value;
                OnPropertyChanged();
            }
        }

        #endregion ForceRemoveUacGroup


    }
}
