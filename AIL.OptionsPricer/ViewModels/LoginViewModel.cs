using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using AIL.OptionsPricer.Common.EventAggregator;
using AIL.OptionsPricer.Models;
using AIL.OptionsPricer.Services;
using Microsoft.Practices.Prism.PubSubEvents;

//using Prism;

namespace AIL.OptionsPricer.ViewModels
{
  public class LoginViewModel : ViewModelBase
  {
    private ICommand _loginCommand;

    private readonly IEventAggregator _eventAggregator;
    private readonly IUserService _userService;
    private ICommand _cancelLoginCommand;

    public LoginViewModel(IEventAggregator eventAggregator, IUserService userService)
    {
      _eventAggregator = eventAggregator;
      _userService = userService;
      CurrentUser = new User() { UserName = "DevUser" };
      Name = "Login";
    }


    public User CurrentUser { get; set; }
    public override string Name { get; }

    public ICommand LoginCommand
    {
      get
      {
        return _loginCommand ?? (_loginCommand = new RelayCommand(param => ExecuteLoginCommand(param),
                 param => CanExecuteLoginCommand(param)));
      }
    }

    public ICommand CancelLoginCommand
    {
      get
      {
        return _cancelLoginCommand ?? (_cancelLoginCommand = new RelayCommand(param => ExecuteCancelLoginCommand(param),
                 param => CanExecuteCancelLoginCommand(param)));
      }
    }

    private bool CanExecuteCancelLoginCommand(object o)
    {
      return true;
    }

    private void ExecuteCancelLoginCommand(object o)
    {
      _eventAggregator.GetEvent<OnCloseControl>().Publish(Name);
    }

    private bool CanExecuteLoginCommand(object o)
    {
      return true;
    }

    private void ExecuteLoginCommand(object o)
    {
      if (!CurrentUser.Validate())
        return;
      if (!ValidateCredentials())
        return;
      CurrentUser.IsLoggedIn = true;
      _eventAggregator.GetEvent<OnLoginSuccess>().Publish(CurrentUser);
    }

    public bool Validate()
    {
      bool ret = false;

      CurrentUser.IsLoggedIn = false;
      ValidationMessages.Clear();
      if (string.IsNullOrEmpty(CurrentUser.UserName))
      {
        AddApplicationExceptionMessage("UserName", "User Name Must Be Filled In");
      }
      if (string.IsNullOrEmpty(CurrentUser.Password))
      {
        AddApplicationExceptionMessage("Password", "Password Must Be Filled In");
      }

      ret = (ValidationMessages.Count == 0);

      return ret;
    }

    public bool ValidateCredentials()
    {
      bool ret = false;
      try
      {
        using (var userService = _userService)
        {
          var user = userService.GetUserByLogin(CurrentUser.UserName);

          if (user != null)
          {
            ret = true;
          }
          else
          {
            AddApplicationExceptionMessage("LoginFailed",
              "Invalid User Name and/or Password.");
          }
        }
      }
      catch (Exception ex)
      {
        AddApplicationExceptionMessage("Unhadled exception", ex.Message);
      }
      return ret;
    }
  }
}
