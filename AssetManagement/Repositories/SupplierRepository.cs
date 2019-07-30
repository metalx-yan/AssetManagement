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
    public class SupplierRepository : ISupplierRepository
    {
        bool status = false;
        ApplicationContext applicationContext = new ApplicationContext();

        public bool Delete(int Id)
        {
            var get = Get(Id);
            if (get != null)
            {
                get.Delete();
                applicationContext.Entry(get).State = EntityState.Modified;
                var result = applicationContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
        }

        public List<Supplier> Get()
        {
            //category yang ada di applicationcontext
            var get = applicationContext.Suppliers.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public List<Supplier> Get(string value)
        {
            var get = applicationContext.Suppliers.Where(x => (x.Id.ToString().Contains(value) || x.Name.Contains(value)) && x.IsDelete == false).ToList();
            return get;
        }

        public Supplier Get(int id)
        {
            var get = applicationContext.Suppliers.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(SupplierVM supplierVM)
        {
            var push = new Supplier(supplierVM);
            if(push != null)
            {
                applicationContext.Suppliers.Add(push);
                var result = applicationContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
            
        }

        public bool Update(int Id, SupplierVM supplierVM)
        {
            var get = Get(Id);
            if (get != null)
            {
                get.Update(supplierVM);
                applicationContext.Entry(get).State = EntityState.Modified;
                var result = applicationContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
