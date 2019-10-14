using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AIL.OptionsPricer.Services;
using AIL.OptionsPricer.Startup;
using AIL.OptionsPricer.ViewModels;
using AIL.OptionsPricer.Views;
using Autofac;
using Unity;

namespace AIL.OptionsPricer
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);
      var mainview = ContainerHelper.Container.Resolve<MainView>();
      mainview.Show();
    }
  }
}
