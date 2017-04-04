using System.Collections.Generic;
using Chayns.Backend.Api.Models.Data.Base;

namespace Chayns.Backend.Api.Models.Data
{
    public class PageAccessTokenDataGet : DefaultData
    {
        public PageAccessTokenDataGet(int locationId, params string[] permissions) : base(locationId)
        {
            if (permissions != null && permissions.Length > 0)
            {
                Permissions = new List<string>(permissions);
            }
            else
            {
                Permissions = new List<string>();
            }
        }

        public PageAccessTokenDataGet(string siteId, params string[] permissions) : base(siteId)
        {
            if (permissions != null && permissions.Length > 0)
            {
                Permissions = new List<string>(permissions);
            }
            else
            {
                Permissions = new List<string>();
            }
        }

        #region Name
        private List<string> _permissions;
        public List<string> Permissions
        {
            get
            {
                return _permissions;
            }
            set
            {
                _permissions = value;
                OnPropertyChanged();
            }
        }
        #endregion Name

        /// <summary>
        /// Gets the location identifier (LocationId or SiteId)
        /// </summary>
        /// <returns>LocationId or SiteId</returns>
        public string GetLocationIdentifier()
        {
            return null;
        }
    }
}
