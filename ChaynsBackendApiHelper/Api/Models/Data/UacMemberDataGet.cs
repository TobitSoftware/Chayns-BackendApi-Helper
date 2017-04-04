using Chayns.Backend.Api.Models.Data.Base;

namespace Chayns.Backend.Api.Models.Data
{
    public class UacMemberDataGet : DefaultData
    {
        public UacMemberDataGet(int locationId) : base(locationId)
        {
        }

        public UacMemberDataGet(string siteId) : base(siteId)
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
        #region FirstName
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        #endregion FirstName
        #region LastName
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        #endregion LastName
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
        #region Gender
        private string _gender;
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }
        #endregion Gender
    }
}
