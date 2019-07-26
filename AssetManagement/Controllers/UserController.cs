using AssetManagement.Models;
using AssetManagement.Repositories;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Controllers
{
    public class UserController
    {
        IUserRepository iuserrepository = new UserRepository();
        public List<User> Get()
        {
            return iuserrepository.Get();
        }
        public User Get(int id)
        {
            return iuserrepository.Get(id);
        }
        public List<User> Get(string value)
        {
            return iuserrepository.Get(value);
        }
        public bool Insert(UserVM userVM)
        {
            return iuserrepository.Insert(userVM);
        }
        public bool Update(int id, UserVM userVM)
        {
            return iuserrepository.Update(id, userVM);
        }
        public bool Delete(int id)
        {
            return iuserrepository.Delete(id);
        }
    }
}
