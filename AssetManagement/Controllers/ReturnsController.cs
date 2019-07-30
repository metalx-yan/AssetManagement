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
    public class ReturnsController
    {
        IReturnRepository iReturnRepository = new ReturnRepository();

        public List<Return> Get()
        {
            return iReturnRepository.Get();
        }

        public Return Get(int Id)
        {
            return iReturnRepository.Get(Id);
        }

        public List<Return> Get(string value)
        {
            return iReturnRepository.Get(value);
        }

        public bool Insert(ReturnVM returnVM)
        {
            return iReturnRepository.Insert(returnVM);
        }

        public bool Update(int id, ReturnVM returnVM)
        {
            return iReturnRepository.Update(id, returnVM);
        }

        public bool Delete(int id)
        {
            return iReturnRepository.Delete(id);
        }
    }
}
