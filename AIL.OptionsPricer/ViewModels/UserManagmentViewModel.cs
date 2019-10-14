using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIL.OptionsPricer.Models;
using AIL.OptionsPricer.Services;

namespace AIL.OptionsPricer.ViewModels
{
  public class UserManagmentViewModel : ViewModelBase
  {
    private ObservableCollection<User> _users;
    private readonly IUserService _userService;
    public UserManagmentViewModel(IUserService userService)
    {
      _userService = userService;
      Name = "UserManagment";
      LoadUsers();
    }
    public override string Name { get; }

    public ObservableCollection<User> Users
    {
      get => _users;
      set
      {
        _users = value;
        RaisePropertyChange();
      }
    }

    public async void LoadUsers()
    {
      try
      {
        using (var userService = _userService)
        {
          var users = await userService.GetAllUsers();

          Users = new ObservableCollection<User>(users);
        }

      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.ToString());
      }
    }
  }
}
