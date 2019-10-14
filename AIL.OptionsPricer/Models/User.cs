using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIL.OptionsPricer.Common;

namespace AIL.OptionsPricer.Models
{
  public class User : ModelBase
  {
    private string _email;
    private int _id;
    private string _userName;
    private string _password;
    private string _firstName;
    private string _lastName;
    private bool _isLoggedIn;
    private bool _isAdmin;

    public int Id
    {
      get => _id;
      set
      {
        _id = value;
        RaisePropertyChange();
      }
    }

    public bool IsAdmin
    {
      get => _isAdmin;
      set
      {
        _isAdmin = value;
        RaisePropertyChange();
      }
    }

    [Required]
    [Display(Name = "User Name")]
    public string UserName
    {
      get => _userName;
      set
      {
        _userName = value;
        ValidateProperty(value);
      }
    }
    [Required]
    public string Password
    {
      get => _password;
      set
      {
        _password = value;
        ValidateProperty(value);
      }
    }

    public string FirstName
    {
      get => _firstName;
      set
      {
        _firstName = value;
        RaisePropertyChange();
      }
    }

    public string LastName
    {
      get => _lastName;
      set
      {
        _lastName = value;
        RaisePropertyChange();
      }
    }

    public string Email
    {
      get => _email;
      set
      {
        _email = value;
        RaisePropertyChange();
      }
    }

    public bool IsLoggedIn
    {
      get => _isLoggedIn;
      set
      {
        _isLoggedIn = value;
        RaisePropertyChange();
      }
    }
  }
}
