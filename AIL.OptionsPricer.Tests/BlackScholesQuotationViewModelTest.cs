using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIL.OptionsPricer.Common.EventAggregator;
using AIL.OptionsPricer.Models;
using AIL.OptionsPricer.Services;
using AIL.OptionsPricer.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using Moq;
using Xunit;

namespace AIL.OptionsPricer.Tests
{
  public class BlackScholesQuotationViewModelTest
  {
    private readonly Mock<IOptionsPricerService> _pricerServiceMock;
    private Mock<IEventAggregator> _eventAggregatorMock;

    private BlackScholesQuotationViewModel _viewModel;
    public BlackScholesQuotationViewModelTest()
    {
      _pricerServiceMock = new Mock<IOptionsPricerService>();
      _eventAggregatorMock = new Mock<IEventAggregator>();

      _pricerServiceMock.Setup(dp => dp.CalculatePremiums(It.IsAny<QuotationInput>()))
        .Returns(Task.FromResult(new QuotationResult() { CallPremium = 5.23, PutPremium = 8.5 }));

      _viewModel = new BlackScholesQuotationViewModel(_pricerServiceMock.Object, _eventAggregatorMock.Object);
    }

    [Fact]
    public void ShouldPublishCloseUserControlEvent()
    {
      var eventMock = new Mock<OnCloseControl>();
      _eventAggregatorMock
        .Setup(ea => ea.GetEvent<OnCloseControl>())
        .Returns(eventMock.Object);
      _viewModel.CloseCommand.Execute(null);
      eventMock.Verify(e => e.Publish(_viewModel.Name), Times.Once);
    }

    [Fact]
    public void ShouldCallCalculatePremiumsMethodOfOptionsPricerServiceWhenGetQuoteCommandIsExecuted()
    {
      var input = new QuotationInput()
      {
        StockPrice = "50.0",
        StrikePrice = "55.0",
        Volatility = "0.2",
        InterestRate = "0.09",
        TimeToMaturity = "1.0"
      };
      _viewModel.QuotationInput = input;

      _viewModel.GetQuoteCommand.Execute(null);
      _pricerServiceMock.Verify(dp => dp.CalculatePremiums(_viewModel.QuotationInput), Times.Once);
    }
  }
}
