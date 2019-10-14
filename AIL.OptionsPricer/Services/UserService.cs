using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AIL.OptionsPricer.Models;
using Newtonsoft.Json;

namespace AIL.OptionsPricer.Services
{
  public class UserService : IUserService
  {
    private const string JsonUsersFile = "Users.json";
    public User GetUserByLogin(string username)
    {
      var users = ReadFromFile();
      return users.SingleOrDefault(u => u.UserName == username);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
      return await Task.Run(() => { return ReadFromFile(); });

    }

    private List<User> ReadFromFile()
    {
      if (File.Exists(JsonUsersFile))
      {
        string json = File.ReadAllText(JsonUsersFile);
        return JsonConvert.DeserializeObject<List<User>>(json);
      }
      else
      {
        return new List<User>();
      }

    }

    public void Dispose()
    {
      // no ressource to dispose
    }
  }
}
