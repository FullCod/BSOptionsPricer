using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIL.OptionsPricer.Models;
using Microsoft.Practices.Prism.PubSubEvents;

namespace AIL.OptionsPricer.Common.EventAggregator
{
  public class OnLoginSuccess : PubSubEvent<User>
  {
  }
}
