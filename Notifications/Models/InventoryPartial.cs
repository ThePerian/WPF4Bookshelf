using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public partial class Inventory : INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors =
            new Dictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return _errors.Values;
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }

        public bool HasErrors => _errors.Count != 0;

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void ClearErrors(string propertyName = "")
        {
            _errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }

        private void AddError(string propertyName, string error)
        {
            AddErrors(propertyName, new List<string> { error });
        }

        private void AddErrors(string propertyName, List<string> errors)
        {
            var changed = false;
            if (!_errors.ContainsKey(propertyName))
            {
                _errors.Add(propertyName, new List<string>());
                changed = true;
            }
            errors.ToList().ForEach(x =>
            {
                if (_errors[propertyName].Contains(x)) return;
                _errors[propertyName].Add(x);
                changed = true;
            });
            if (changed)
                OnErrorsChanged(propertyName);
        }
    }
}
