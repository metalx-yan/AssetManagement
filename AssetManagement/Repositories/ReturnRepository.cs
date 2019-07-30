using AssetManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagement.Models;
using AssetManagement.Context;
using AssetManagement.ViewModels;
using System.Data.Entity;

namespace AssetManagement.Repositories
{
    public class ReturnRepository : IReturnRepository
    {
        bool status = false;
        ApplicationContext applicationContext = new ApplicationContext();

        public List<Return> Get()
        {
            var get = applicationContext.Returns.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public List<Return> Get(string ReturnDate)
        {
            var get = applicationContext.Returns.Where(x => (x.ReturnDate.ToString().Contains(ReturnDate) || x.IsDelete == false)).ToList();
            return get;
        }

        public Return Get(int id)
        {
            var get = applicationContext.Returns.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(ReturnVM returnVM)
        {
            var push = new Return(returnVM);
            applicationContext.Returns.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, ReturnVM returnVM)
        {
            var get = Get(id);
            get.Update(returnVM);
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Delete(int id)
        {
            var get = Get(id);
            get.Delete();
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

      
    }
}
