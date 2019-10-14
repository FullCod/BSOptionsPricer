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
using Unity;

namespace AIL.OptionsPricer
{
  /// <summary>
  /// Interaction logic for MainView.xaml
  /// </summary>
  public partial class MainView : Window
  {
    private MainViewModel _viewModel = null;
    public MainView()
    {
      InitializeComponent();
      _viewModel = ContainerHelper.Container.Resolve<MainViewModel>();
      this.DataContext = _viewModel;
    }

  }
}
