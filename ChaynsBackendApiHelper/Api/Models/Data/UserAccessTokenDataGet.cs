using System.Linq;
using Chayns.Backend.Api.Models.Data.Base;

namespace Chayns.Backend.Api.Models.Data
{
    public class UserAccessTokenDataGet : DefaultData
    {
        public UserAccessTokenDataGet(int locationId, params int[] requieredUacGroups) : base(locationId)
        {
            if (requieredUacGroups != null && requieredUacGroups.Length > 0)
            {
                RequieredUacGroups = requieredUacGroups.ToArray();
            }
        }

        public UserAccessTokenDataGet(string siteId, params int[] requieredUacGroups) : base(siteId)
        {
            if (requieredUacGroups != null && requieredUacGroups.Length > 0)
            {
                RequieredUacGroups = requieredUacGroups.ToArray();
            }
        }

        #region RequieredUacGroups

        private int[] _requieredUacGroups;

        public int[] RequieredUacGroups
        {
            get { return _requieredUacGroups; }
            set
            {
                _requieredUacGroups = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
