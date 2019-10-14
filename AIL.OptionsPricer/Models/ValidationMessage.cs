using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIL.OptionsPricer.Common;

namespace AIL.OptionsPricer.Models
{
  public class ValidationMessage : PropertyChangedNotifier
  {
    #region Private Properties
    private string _PropertyName;
    private string _Message;
    #endregion

    #region Public Properties
    public string PropertyName
    {
      get { return _PropertyName; }
      set
      {
        _PropertyName = value;
        RaisePropertyChange();
      }
    }

    public string Message
    {
      get { return _Message; }
      set
      {
        _Message = value;
        RaisePropertyChange();
      }
    }
    #endregion
  }
}
