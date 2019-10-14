using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AIL.OptionsPricer.Common.EventAggregator;
using AIL.OptionsPricer.Models;
using AIL.OptionsPricer.Services;
using Microsoft.Practices.Prism.PubSubEvents;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AIL.OptionsPricer.ViewModels
{
  public class BlackScholesQuotationViewModel : ViewModelBase
  {
    private readonly Dictionary<string, ICollection<string>> _validationErrors = new Dictionary<string, ICollection<string>>();
    private ICommand _getQuoteCommand;
    private readonly IOptionsPricerService _pricerService;
    private ICommand _clearCommand;
    private QuotationInput _quotationInput;
    private QuotationResult _quotationResult;
    private ICommand _closeCommand;
    private readonly IEventAggregator _eventAggregator;

    public BlackScholesQuotationViewModel(IOptionsPricerService pricerService, IEventAggregator eventAggregator)
    {
      _pricerService = pricerService;
      _eventAggregator = eventAggregator;
      QuotationInput = new QuotationInput();
      QuotationResult = new QuotationResult();
      Name = "BlackScholes";
    }
    public override string Name { get; }
    public QuotationInput QuotationInput
    {
      get => _quotationInput;
      set
      {
        _quotationInput = value;
        RaisePropertyChange();
      }
    }

    public QuotationResult QuotationResult
    {
      get => _quotationResult;
      set
      {
        _quotationResult = value;
        RaisePropertyChange();
      }
    }

    public ICommand GetQuoteCommand
    {
      get
      {
        return _getQuoteCommand ?? (_getQuoteCommand = new RelayCommand(param => ExecuteGetQuoteCommand(param),
                 param => CanExecuteGetQuoteCommand(param)));
      }
    }

    public ICommand ClearCommand
    {
      get
      {
        return _clearCommand ?? (_clearCommand = new RelayCommand(param => ExecuteClearCommand(param),
                 param => CanExecuteClearCommand(param)));
      }
    }

    public ICommand CloseCommand
    {
      get
      {
        return _closeCommand ?? (_closeCommand = new RelayCommand(param => ExecuteCloseCommand(param),
                 param => CanExecuteCloseCommand(param)));
      }
    }

    private bool CanExecuteCloseCommand(object param)
    {
      return true;
    }

    private void ExecuteCloseCommand(object param)
    {
      _eventAggregator.GetEvent<OnCloseControl>().Publish(Name);
    }

    private void ExecuteClearCommand(object param)
    {
      QuotationInput = new QuotationInput();
      QuotationResult = new QuotationResult();
      ValidationMessages.Clear();
      IsValidationVisible = false;
    }

    private async void ExecuteGetQuoteCommand(object param)
    {
      QuotationResult quotes = null;
      try
      {
        if (!QuotationInput.Validate())
          return;
        quotes = await Task.Run(() =>
        {
          return _pricerService.CalculatePremiums(QuotationInput);
        });
      }
      catch (Exception ex)
      {
        AddApplicationExceptionMessage("Unhandled error",
          ex.Message);
      }
      QuotationResult = quotes;
    }
    private bool CanExecuteGetQuoteCommand(object param)
    {
      return true;
    }
    private bool CanExecuteClearCommand(object param)
    {
      return true;
    }
  }
}
