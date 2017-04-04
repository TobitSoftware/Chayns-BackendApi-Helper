using Chayns.Backend.Api.Models.Data.Base;

namespace Chayns.Backend.Api.Models.Data
{
    public class UacMemberDataDelete : DefaultData
    {
        public UacMemberDataDelete(int locationId) : base(locationId)
        {
        }

        public UacMemberDataDelete(string siteId) : base(siteId)
        {
        }

        #region UserId
        private int _userId;
        public int UserId
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
    }
}
