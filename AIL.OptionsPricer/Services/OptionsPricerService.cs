using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using AIL.OptionsPricer.Models;
using DevExpress.Utils.OAuth;
using Universal.Common.Mathematics;
using Math = System.Math;

namespace AIL.OptionsPricer.Services
{
  public class OptionsPricerService : IOptionsPricerService
  {
    public Task<QuotationResult> CalculatePremiums(QuotationInput quoteparams)
    {
      try
      {
        return Task.Run(() =>
        {
          double d1 = 0.0;
          double d2 = 0.0;
          QuotationResult quotes = new QuotationResult();
          double S = double.Parse(quoteparams.StockPrice.Replace(".", ","));
          double K = double.Parse(quoteparams.StrikePrice.Replace(".", ","));
          double T = double.Parse(quoteparams.TimeToMaturity.Replace(".", ","));
          double r = double.Parse(quoteparams.InterestRate.Replace(".", ","));
          double v = double.Parse(quoteparams.Volatility.Replace(".", ","));

          d1 = Math.Round((Math.Log(S / K) + (r + v * v / 2.0) * T) / v / Math.Sqrt(T), 4);
          d2 = Math.Round(d1 - v * Math.Sqrt(T), 4);

          quotes.D1 = d1;
          quotes.D2 = d2;

          quotes.CallPremium = Math.Round(S * CumulativeNormDistFunction(d1) - K * Math.Exp(-r * T) * CumulativeNormDistFunction(d2), 4);
          quotes.PutPremium = Math.Round(K * Math.Exp(-r * T) * CumulativeNormDistFunction(-d2) - S * CumulativeNormDistFunction(-d1), 4);

          return quotes;
        });
      }
      catch (Exception ex)
      {
        throw;
      }
    }


    static double CumulativeNormDistFunction(double x)
    {
      try
      {
        double b0 = 0.2316419;
        double b1 = 0.319381530;
        double b2 = -0.356563782;
        double b3 = 1.781477937;
        double b4 = -1.821255978;
        double b5 = 1.330274429;
        double pi = Math.PI;
        double phi = Math.Exp(-x * x / 2.0) / Math.Sqrt(2.0 * pi);
        double t, c;
        double CDF = 0.5;
        if (x > 0.0)
        {
          t = 1.0 / (1.0 + b0 * x);
          CDF = 1.0 - phi * (b1 * t + b2 * Math.Pow(t, 2) + b3 * Math.Pow(t, 3) + b4 * Math.Pow(t, 4) + b5 * Math.Pow(t, 5));
        }
        else if (x < 0.0)
        {
          x = -x;
          t = 1.0 / (1.0 + b0 * x);
          c = 1.0 - phi * (b1 * t + b2 * Math.Pow(t, 2) + b3 * Math.Pow(t, 3) + b4 * Math.Pow(t, 4) + b5 * Math.Pow(t, 5));
          CDF = 1.0 - c;
        }
        return CDF;
      }
      catch (Exception ex)
      {

        throw;
      }
    }
  }
}
