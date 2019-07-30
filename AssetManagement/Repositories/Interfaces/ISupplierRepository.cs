using AssetManagement.Models;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        List<Supplier> Get();
        Supplier Get(int id);
        List<Supplier> Get(string value);
        bool Insert(SupplierVM supplierVM);
        bool Update(int Id, SupplierVM supplierVM);
        bool Delete(int Id);
    }
}
