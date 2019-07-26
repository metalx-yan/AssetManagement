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
    public class RoleRepository : IRoleRepository
    {
        bool status = false;
        //buat objek
        ApplicationContext applicationcontext = new ApplicationContext();

        public bool Delete(int id)
        {
            var get = Get(id);
            get.Delete();
            applicationcontext.Entry(get).State = EntityState.Modified;
            var result = applicationcontext.SaveChanges();
            return result > 0;
        }

        public List<Role> Get()
        {
            // Categories yang ada di applicationcontext
            var get = applicationcontext.Roles.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public List<Role> Get(string value)
        {
            //var c = Convert.ToInt32(value);
            // contains artinya mengandung value yang ada di colom
            var get = applicationcontext.Roles.Where(x => (x.Name.Contains(value) || Convert.ToString(x.Id).Contains(value)) && x.IsDelete == false).ToList();
            return get;
        }

        public Category Get(int id)
        {
            // var get = applicationcontext.Categories.Where(x => x.IsDelete == false && x.Id == id).SingleOrDefault();
            var get = applicationcontext.Categories.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(RoleVM roleVM)
        {
            var push = new Role(roleVM);
            applicationcontext.Roles.Add(push);
            var result = applicationcontext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, RoleVM roleVM)
        {
            var get = Get(id);
            get.Update(roleVM);
            // entry data yang akan di ubah, state mengacu sebelah kanan supaya kita mendapatkan modified
            applicationcontext.Entry(get).State = EntityState.Modified;
            var result = applicationcontext.SaveChanges();
            return result > 0;
        }

        Role IRoleRepository.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
