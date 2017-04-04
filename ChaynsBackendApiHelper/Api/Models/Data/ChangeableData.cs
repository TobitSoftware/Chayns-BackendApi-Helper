using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Chayns.Backend.Api.Models.Data
{
    public class ChangeableData
    {
        public ChangeableData()
        {
            PropertyChanged += DefaultData_PropertyChanged;
        }

        #region PropertyChanged functions
        private void DefaultData_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _changedProperties.Add(e.PropertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly HashSet<string> _changedProperties = new HashSet<string>();

        public HashSet<string> GetAllChangedProperties()
        {
            return _changedProperties;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null, string setPropertyName = null)
        {
            if (string.IsNullOrWhiteSpace(setPropertyName))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            else
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(setPropertyName));
            }
        }

        #endregion PropertyChanged fuctions
    }
}
