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
    public class SuppliersController
    {
        ISupplierRepository iSupplierRepository = new SupplierRepository();
        public List<Supplier> Get()
        {
            return iSupplierRepository.Get();
        }

        public Supplier Get(int id)
        {
            return iSupplierRepository.Get(id);
        }

        public List<Supplier> Get(string value)
        {
            return iSupplierRepository.Get(value);
        }

        public bool Insert(SupplierVM supplierVM)
        {
            return iSupplierRepository.Insert(supplierVM);
        }

        public bool Update(int Id, SupplierVM supplierVM)
        {
            return iSupplierRepository.Update(Id, supplierVM);
        }

        public bool Delete(int Id)
        {
            return iSupplierRepository.Delete(Id);
        }
    }
}
