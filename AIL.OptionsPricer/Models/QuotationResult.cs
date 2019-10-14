using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIL.OptionsPricer.Common;

namespace AIL.OptionsPricer.Models
{
  public class QuotationResult : PropertyChangedNotifier
  {
    private double _callPremium;
    private double _putPremium;
    private double _d1;
    private double _d2;

    public double CallPremium
    {
      get => _callPremium;
      set
      {
        _callPremium = value;
        RaisePropertyChange();
      }
    }

    public double PutPremium
    {
      get => _putPremium;
      set
      {
        _putPremium = value;
        RaisePropertyChange();
      }
    }

    public double D1
    {
      get => _d1;
      set
      {
        _d1 = value;
        RaisePropertyChange();
      }
    }

    public double D2
    {
      get => _d2;
      set
      {
        _d2 = value;
        RaisePropertyChange();
      }
    }
  }
}
