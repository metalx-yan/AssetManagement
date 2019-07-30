using AssetManagement.Context;
using AssetManagement.Models;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        bool status = false;

        ApplicationContext applicationcontext = new ApplicationContext();
        public bool Delete(int id)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Delete();
                applicationcontext.Entry(get).State = EntityState.Modified;
                var result = applicationcontext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }            
        }
        public List<User> Get()
        {
            // Categories yang ada di applicationcontext
            var get = applicationcontext.Users.Where(x => x.IsDelete == false).Include("Role").ToList();
            return get;
        }

        public List<User> Get(string value)
        {
            //var c = Convert.ToInt32(value);
            // contains artinya mengandung value yang ada di colom
            var get = applicationcontext.Users.Where(x => (x.Email.Contains(value) || Convert.ToString(x.Id).Contains(value)) && x.IsDelete == false).ToList();
            return get;
        }

        public User Get(int id)
        {
            // var get = applicationcontext.Categories.Where(x => x.IsDelete == false && x.Id == id).SingleOrDefault();
            var get = applicationcontext.Users.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(UserVM userVM)
        {
            var push = new User(userVM);
            if (push != null)
            {
                var getRole = applicationcontext.Roles.SingleOrDefault(x => x.IsDelete == false && x.Id == userVM.RoleId);
                push.Role = getRole;
                applicationcontext.Users.Add(push);
                var result = applicationcontext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }            
        }
        public bool Update(int id, UserVM userVM)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Update(userVM);
                // entry data yang akan di ubah, state mengacu sebelah kanan supaya kita mendapatkan modified
                applicationcontext.Entry(get).State = EntityState.Modified;
                var result = applicationcontext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
        }

        User IUserRepository.Get(int id)
        {
            throw new NotImplementedException();
        }

        List<User> IUserRepository.Get(string value)
        {
            throw new NotImplementedException();
        }
    }
}
