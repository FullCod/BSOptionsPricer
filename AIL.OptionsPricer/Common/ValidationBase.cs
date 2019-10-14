using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AIL.OptionsPricer.Models;

namespace AIL.OptionsPricer.Common
{
  public class ValidationBase : INotifyDataErrorInfo
  {
    private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
    private object _lock = new object();

    public void ValidateProperty(object value, [CallerMemberName] string propertyName = null)
    {
      lock (_lock)
      {
        var validationContext = new ValidationContext(this, null, null);
        validationContext.MemberName = propertyName;
        var validationResults = new List<ValidationResult>();
        Validator.TryValidateProperty(value, validationContext, validationResults);

        if (_errors.ContainsKey(propertyName))
          _errors.Remove(propertyName);
        OnErrorsChanged(propertyName);
        HandleValidationResults(validationResults);
      }
    }
    private ObservableCollection<ValidationMessage> _ValidationMessages = new ObservableCollection<ValidationMessage>();
    public ObservableCollection<ValidationMessage> ValidationMessages
    {
      get => _ValidationMessages;
      set
      {
        _ValidationMessages = value;
      }
    }

    private void HandleValidationResults(List<ValidationResult> validationResults)
    {

      var resultsByPropNames = from res in validationResults
                               from mname in res.MemberNames
                               group res by mname into g
                               select g;

      foreach (var prop in resultsByPropNames)
      {
        var messages = prop.Select(r => r.ErrorMessage).ToList();
        _errors.Add(prop.Key, messages);
        OnErrorsChanged(prop.Key);
      }
    }

    public IEnumerable GetErrors(string propertyName)
    {
      if (!string.IsNullOrEmpty(propertyName))
      {
        if (_errors.ContainsKey(propertyName) && (_errors[propertyName] != null) && _errors[propertyName].Count > 0)
          return _errors[propertyName].ToList();
        else
          return null;
      }
      else
        return _errors.SelectMany(err => err.Value.ToList());
    }

    public bool Validate()
    {
      lock (_lock)
      {
        var validationContext = new ValidationContext(this, null, null);
        var validationResults = new List<ValidationResult>();
        Validator.TryValidateObject(this, validationContext, validationResults, true);

        var propNames = _errors.Keys.ToList();
        _errors.Clear();
        propNames.ForEach(pn => OnErrorsChanged(pn));
        HandleValidationResults(validationResults);
        return !_errors.Any();
      }

    }

    public void OnErrorsChanged(string propertyName)
    {
      if (ErrorsChanged != null)
        ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
    }
    public bool HasErrors { get { return _errors.Any(propErrors => propErrors.Value != null && propErrors.Value.Count > 0); } }
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
  }
}
