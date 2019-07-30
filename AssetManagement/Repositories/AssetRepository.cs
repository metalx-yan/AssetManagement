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
    public class AssetRepository : IAssetRepository
    {
        bool status = false;
        ApplicationContext applicationContext = new ApplicationContext();

        public bool Delete(int Id)
        {
            var get = Get(Id);
            get.Delete();
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public List<Asset> Get()
        {
            //category yang ada di applicationcontext
            var get = applicationContext.Assets.Where(x => x.IsDelete == false).Include("Supplier").Include("Category").ToList();
            return get;
        }

        public List<Asset> Get(string value)
        {
            var get = applicationContext.Assets.Where(x => (x.Id.ToString().Contains(value) || x.Name.Contains(value)) && x.IsDelete == false).ToList();
            return get;
        }

        public Asset Get(int id)
        {
            var get = applicationContext.Assets.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(AssetVM assetVM)
        {
            var push = new Asset(assetVM);
            var getSupplier = applicationContext.Suppliers.SingleOrDefault(x => x.IsDelete == false && x.Id == assetVM.SupplierId);
            push.Supplier = getSupplier;
            var getSupplier1 = applicationContext.Categories.SingleOrDefault(x => x.IsDelete == false && x.Id == assetVM.CategoryId);
            push.Category = getSupplier1;
            applicationContext.Assets.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int Id, AssetVM assetVM)
        {
            var get = Get(Id);
            var getSupplier = applicationContext.Suppliers.SingleOrDefault(x => x.IsDelete == false && x.Id == assetVM.SupplierId);
            get.Supplier = getSupplier;
            var getSupplier1 = applicationContext.Categories.SingleOrDefault(x => x.IsDelete == false && x.Id == assetVM.CategoryId);
            get.Category = getSupplier1;
            get.Update(assetVM);
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }
    }
}
