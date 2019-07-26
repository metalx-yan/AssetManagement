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
    public class CategoriesController
    {
        ICategoryRepository icategoryrepository = new CategoryRepository();
        //buat method
        public List<Category> Get()
        {
            return icategoryrepository.Get();
        }

        public Category Get(int id)
        {
            return icategoryrepository.Get(id);
        }

        //search
        public List<Category> Get(string value)
        {
            return icategoryrepository.Get(value);
        }
        // categoryVM adalah object
        public bool Insert(CategoryVM categoryVM)
        {
            return icategoryrepository.Insert(categoryVM);
        }

        public bool Update(int id, CategoryVM categoryVM)
        {
            return icategoryrepository.Update(id, categoryVM);
        }

        public bool Delete(int id)
        {
            return icategoryrepository.Delete(id);
        }      
    }
}
