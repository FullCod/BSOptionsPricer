using System.Collections.ObjectModel;
using AIL.OptionsPricer.Common;
using AIL.OptionsPricer.Models;

namespace AIL.OptionsPricer.ViewModels
{
  public abstract class ViewModelBase : PropertyChangedNotifier
  {
    private ObservableCollection<ValidationMessage> _ValidationMessages = new ObservableCollection<ValidationMessage>();
    private bool _IsValidationVisible = false;
    public abstract string Name { get; }

    public ObservableCollection<ValidationMessage> ValidationMessages
    {
      get => _ValidationMessages;
      set
      {
        _ValidationMessages = value;
        RaisePropertyChange();
      }
    }

    public bool IsValidationVisible
    {
      get { return _IsValidationVisible; }
      set
      {
        _IsValidationVisible = value;
        RaisePropertyChange();
      }
    }

    public virtual void AddApplicationExceptionMessage(string propertyName, string msg)
    {
      _ValidationMessages.Add(new ValidationMessage { Message = msg, PropertyName = propertyName });
      IsValidationVisible = true;
    }
  }
}
