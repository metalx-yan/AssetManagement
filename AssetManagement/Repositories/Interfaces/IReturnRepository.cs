using AssetManagement.Models;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Repositories.Interfaces
{
    public interface IReturnRepository
    {
        List<Return> Get();
        Return Get(int id);
        List<Return> Get(string value);
        bool Insert(ReturnVM returnVM);
        bool Update(int id, ReturnVM returnVM);
        bool Delete(int id);
    }
}
