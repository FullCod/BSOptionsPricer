using AIL.OptionsPricer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIL.OptionsPricer.Services;
using Xunit;

namespace AIL.OptionsPricer.Tests
{

  public class OptionsPricerServiceTest
  {
    [Fact]
    public void CalculatePremiums_should_return_double()
    {
      //Arrange
      var pricer = new OptionsPricerService();
      var input = new QuotationInput()
      {
        StockPrice = "50.0",
        StrikePrice = "55.0",
        Volatility = "0.2",
        InterestRate = "0.09",
        TimeToMaturity = "1.0"
      };
      QuotationResult expected = new QuotationResult()
      {
        CallPremium = 3.8617,
        PutPremium = 4.1279
      };
      //Act
      var result = pricer.CalculatePremiums(input);
      //Assert
      Assert.Equal(expected.CallPremium, result.Result.CallPremium);
      Assert.Equal(expected.PutPremium, result.Result.PutPremium);
    }
    [Fact]
    public void CalculatePremiums_should_return_double2()
    {
      //Arrange
      var pricer = new OptionsPricerService();
      var input = new QuotationInput()
      {
        StockPrice = "64.0",
        StrikePrice = "60.0",
        Volatility = "0.27",
        InterestRate = "0.045",
        TimeToMaturity = (180.0 / 365.0).ToString(CultureInfo.InvariantCulture)
      };
      QuotationResult expected = new QuotationResult()
      {
        CallPremium = 7.7661,
        PutPremium = 2.4493
      };
      //Act
      var result = pricer.CalculatePremiums(input);
      //Assert
      Assert.Equal(expected.CallPremium, result.Result.CallPremium, 3);
      Assert.Equal(expected.PutPremium, result.Result.PutPremium, 3);
    }
  }
}
