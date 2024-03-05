using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineMakingMonitoringApp.ViewModels
{
    public abstract class BaseViewModel<T> : ObservableObject<T>, INotifyDataErrorInfo
    {
        private string? _viewTitle;

        public string ViewTitle
        {
            get
            {
                return _viewTitle;
            }

            set
            {
                if (_viewTitle == value)
                    return;
                _viewTitle = value;
                OnPropertyChanged("ViewTitle");
            }
        }
        #region Implementation of INotifyDataErrorInfo

        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public IEnumerable? GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                // Provide all the error collections.
                return (_errors.Values);
            }
            // Provice the error collection for the requested property
            // (if it has errors).
            return _errors.ContainsKey(propertyName) ? (_errors[propertyName]) : null;
        }

        public bool HasErrors
        {
            get
            {
                // Indicate whether the entire ViewModel objet is error-free.
                return (_errors.Count > 0);
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        internal void SetErrors(string propertyName, List<string> propertyErrors)
        {
            // Clear any errors that already exist for this property.
            _errors.Remove(propertyName);

            // Add the list collection for the specified property.
            _errors.Add(propertyName, propertyErrors);

            // Raise the error-notification event.
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        internal void ClearErrors(string propertyName)
        {
            // Remove the error list for this property.
            _errors.Remove(propertyName);

            // Raise the error-notification event.
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion
    }
}