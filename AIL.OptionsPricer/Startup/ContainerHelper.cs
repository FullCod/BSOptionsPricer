using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIL.OptionsPricer.Services;
using AIL.OptionsPricer.ViewModels;
using AIL.OptionsPricer.Views;
using Autofac;
using Microsoft.Practices.Prism.PubSubEvents;

namespace AIL.OptionsPricer.Startup
{
  public static class ContainerHelper
  {
    private static IContainer _container;

    static ContainerHelper()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<BlackScholesQuotationView>().AsSelf();
      builder.RegisterType<BlackScholesQuotationViewModel>().AsSelf();
      builder.RegisterType<UserManagmentView>().AsSelf();
      builder.RegisterType<UserManagmentViewModel>().AsSelf();
      builder.RegisterType<MainView>().AsSelf();
      builder.RegisterType<MainViewModel>().AsSelf();
      builder.RegisterType<LoginViewModel>().AsSelf();
      builder.RegisterType<LoginView>().AsSelf();
      builder.RegisterType<OptionsPricerService>().As<IOptionsPricerService>();
      builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
      builder.RegisterType<UserService>().As<IUserService>();
      _container = builder.Build();
    }

    public static IContainer Container => _container;
  }
}
