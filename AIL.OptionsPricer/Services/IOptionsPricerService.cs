using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIL.OptionsPricer.Models;

namespace AIL.OptionsPricer.Services
{
  public interface IOptionsPricerService
  {
    Task<QuotationResult> CalculatePremiums(QuotationInput quoteparams);
  }
}
