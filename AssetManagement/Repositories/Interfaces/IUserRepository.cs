using AssetManagement.Models;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Repositories.Interfaces
{
    public interface IUserRepository 
    {
        List<User> Get();
        User Get(int id);
        List<User> Get(string value);
        bool Insert(UserVM userVM);
        bool Update(int id, UserVM userVM);
        bool Delete(int id);
    }
}
