using AssetManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagement.Models;
using AssetManagement.ViewModels;
using AssetManagement.Context;
using System.Data.Entity;

namespace AssetManagement.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        bool status = false;
        //buat objek
        ApplicationContext applicationcontext = new ApplicationContext();

        public bool Delete(int id)
        {
            var get = Get(id);
            if(get != null)
            {
                get.Delete();
                applicationcontext.Entry(get).State = EntityState.Modified;
                var result = applicationcontext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            } 
        }

        public List<Category> Get()
        {
            // Categories yang ada di applicationcontext
            var get = applicationcontext.Categories.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public List<Category> Get(string value)
        {
            //var c = Convert.ToInt32(value);
            // contains artinya mengandung value yang ada di colom
            var get = applicationcontext.Categories.Where(x => (x.Name.Contains(value) || Convert.ToString(x.Id).Contains(value)) && x.IsDelete == false ).ToList();
            return get;
        }

        public Category Get(int id)
        {
            // var get = applicationcontext.Categories.Where(x => x.IsDelete == false && x.Id == id).SingleOrDefault();
            var get = applicationcontext.Categories.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(CategoryVM categoryVM)
        {
            var push = new Category(categoryVM);
            if (push != null)
            {
                applicationcontext.Categories.Add(push);
                var result = applicationcontext.SaveChanges();
                return result > 0;
            }else
            {
                return false;
            }
        }

        public bool Update(int id,CategoryVM categoryVM)
        {
            var get = Get(id);
            if(get != null)
            {
                get.Update(categoryVM);
                // entry data yang akan di ubah, state mengacu sebelah kanan supaya kita mendapatkan modified
                applicationcontext.Entry(get).State = EntityState.Modified;
                var result = applicationcontext.SaveChanges();
                return result > 0;
            }else
            {
                return false;
            }
            
        }
    }
}
