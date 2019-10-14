using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AIL.OptionsPricer.Startup;
using AIL.OptionsPricer.ViewModels;
using Autofac;


namespace AIL.OptionsPricer.Views
{
  /// <summary>
  /// Interaction logic for BlackAndAcholesQuotationView.xaml
  /// </summary>
  public partial class BlackScholesQuotationView : UserControl
  {

    public BlackScholesQuotationView()
    {
      InitializeComponent();
      this.DataContext = ContainerHelper.Container.Resolve<BlackScholesQuotationViewModel>();
    }

 
  }
}
