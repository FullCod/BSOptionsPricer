using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIL.OptionsPricer.Common;

namespace AIL.OptionsPricer.Models
{
  public class QuotationInput : ModelBase
  {
    private string _stockPrice;
    private string _strikePrice;
    private string _timeToMaturity;
    private string _volatility;
    private string _interestRate;

    [RegularExpression(@"^-?(0|[1-9]\d*)(\.\d+)?$", ErrorMessage = "Strock price must be a double value")]
    [Required]
    public string StockPrice
    {
      get => _stockPrice;
      set
      {
        _stockPrice = value;
        ValidateProperty(value);
      }
    }
    [RegularExpression(@"^-?(0|[1-9]\d*)(\.\d+)?$", ErrorMessage = "Strike price must be a double value")]
    [Required]
    public string StrikePrice
    {
      get => _strikePrice;
      set
      {
        _strikePrice = value;
        ValidateProperty(value);
      }
    }
    [RegularExpression(@"^-?(0|[1-9]\d*)(\.\d+)?$", ErrorMessage = "Time to maturity must be a double value")]
    [Required]
    public string TimeToMaturity
    {
      get => _timeToMaturity;
      set
      {
        _timeToMaturity = value;
        ValidateProperty(value);
      }
    }
    [RegularExpression(@"^-?(0|[1-9]\d*)(\.\d+)?$", ErrorMessage = "Volatility must be a double value")]
    [Required]
    public string Volatility
    {
      get => _volatility;
      set
      {
        _volatility = value;
        RaisePropertyChange();
      }
    }
    [RegularExpression(@"^-?(0|[1-9]\d*)(\.\d+)?$", ErrorMessage = "InterestRate must be a double value")]
    [Required]
    public string InterestRate
    {
      get => _interestRate;
      set
      {
        _interestRate = value;
        RaisePropertyChange();
      }
    }
  }
}
