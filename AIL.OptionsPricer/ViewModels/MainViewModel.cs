using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AIL.OptionsPricer.Common.EventAggregator;
using AIL.OptionsPricer.Models;
using AIL.OptionsPricer.Startup;
using Autofac;
using Microsoft.Practices.Prism.PubSubEvents;

namespace AIL.OptionsPricer.ViewModels
{
  public class MainViewModel : ViewModelBase
  {
    private readonly IEventAggregator _eventAggregator;
    private string _loginMenuHeader;
    private ViewModelBase _currentView;
    private List<ViewModelBase> _pageViewModels;
    private ICommand _switchViewCommand;
    private ICommand _exitCommand;
    private User _currentUser;
    public MainViewModel(IEventAggregator eventAggregator)
    {
      _eventAggregator = eventAggregator;
      _eventAggregator.GetEvent<OnCloseControl>().Subscribe(handleCloseControl);
      _eventAggregator.GetEvent<OnLoginSuccess>().Subscribe(handleLoginSuccess);
      CurrentUser = new User();
      LoginMenuHeader = "Login";
      PageViewModels.Add(ContainerHelper.Container.Resolve<LoginViewModel>());
      PageViewModels.Add(ContainerHelper.Container.Resolve<BlackScholesQuotationViewModel>());
      PageViewModels.Add(ContainerHelper.Container.Resolve<UserManagmentViewModel>());
      CurrentView = PageViewModels[0];
    }

    private void handleLoginSuccess(User user)
    {
      CurrentView = null;
      CurrentUser = user;
      LoginMenuHeader = "Logout " + CurrentUser.UserName;
    }

    private void handleCloseControl(string controlName)
    {
      CurrentView = null;
    }

    public User CurrentUser
    {
      get => _currentUser;
      set
      {
        _currentUser = value;
        RaisePropertyChange();
      }
    }

    public List<ViewModelBase> PageViewModels => _pageViewModels ?? (_pageViewModels = new List<ViewModelBase>());
    public override string Name { get; }
    public string LoginMenuHeader
    {
      get => _loginMenuHeader;
      set
      {
        _loginMenuHeader = value;
        RaisePropertyChange();
      }
    }

    public ViewModelBase CurrentView
    {
      get => _currentView;
      set
      {
        _currentView = value;
        RaisePropertyChange();
      }
    }

    public ICommand SwitchViewCommand
    {

      get
      {
        return _switchViewCommand ?? (_switchViewCommand = new RelayCommand(
                 param => ExecuteSwitchViewCommand((string)param),
                 param => CanExecuteSwitchViewCommand((string)param)));
      }
    }

    public ICommand ExitCommand
    {
      get
      {
        return _exitCommand ?? (_exitCommand = new RelayCommand(
                 param => ExecuteExitCommand((Window)param),
                 param => CanExecuteExitCommand((Window)param)));
      }
    }

    private bool CanExecuteExitCommand(Window win)
    {
      return true;
    }

    private void ExecuteExitCommand(Window win)
    {
      win.Close();
    }

    private bool CanExecuteSwitchViewCommand(string view)
    {
      return true;
    }

    private void ExecuteSwitchViewCommand(string view)
    {
      {
        if (CurrentUser.IsLoggedIn && view.ToLower() == "login")
        {
          CurrentUser = new User();
          CurrentView = null;
          LoginMenuHeader = "Login";
        }
        else
        {
          CurrentView = PageViewModels
            .FirstOrDefault(vm => vm.Name?.ToLower() == view?.ToLower());
        }
      }
    }
  }
}
