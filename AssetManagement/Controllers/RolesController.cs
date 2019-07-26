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
    public class RolesController
    {
        IRoleRepository irolerepository = new RoleRepository();

        public List<Role> Get()
        {
            return irolerepository.Get();
        }

        public Role Get(int id)
        {
            return irolerepository.Get(id);
        }

        //search
        public List<Role> Get(string value)
        {
            return irolerepository.Get(value);
        }

        // categoryVM adalah object
        public bool Insert(RoleVM roleVM)
        {
            return irolerepository.Insert(roleVM);
        }

        public bool Update(int id, RoleVM roleVM)
        {
            return irolerepository.Update(id, roleVM);
        }

        public bool Delete(int id)
        {
            return irolerepository.Delete(id);
        }
    }
}
