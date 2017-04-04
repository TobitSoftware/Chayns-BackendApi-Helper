using Chayns.Backend.Api.Models.Data.Base;

namespace Chayns.Backend.Api.Models.Data
{
    public class UserDataGet : DefaultData
    {
        public UserDataGet(int locationId) : base(locationId)
        {
        }

        public UserDataGet(string siteId) : base(siteId)
        {
        }

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
        #region PersonId
        private string _personId;
        public string PersonId
        {
            get
            {
                return _personId;
            }
            set
            {
                _personId = value;
                OnPropertyChanged();
            }
        }
        #endregion PersonId
        #region QrCode
        private string _qrCode;
        public string QrCode
        {
            get
            {
                return _qrCode;
            }
            set
            {
                _qrCode = value;
                OnPropertyChanged();
            }
        }
        #endregion QrCode
        #region Rfid
        private string _rfid;
        public string Rfid
        {
            get
            {
                return _rfid;
            }
            set
            {
                _rfid = value;
                OnPropertyChanged();
            }
        }
        #endregion Rfid
    }
}
