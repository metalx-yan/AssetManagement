using AssetManagement.Models;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> Get();
        Category Get(int id);
        //search
        List<Category> Get(string value);

        // categoryVM adalah object
        bool Insert(CategoryVM categoryVM);

        bool Update(int id, CategoryVM categoryVM);

        bool Delete(int id);
    }
}
