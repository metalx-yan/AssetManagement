using AssetManagement.Core;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class Category : BaseModel
    {
        public Category() { }
        public Category(CategoryVM categoryVM) {
            this.Name = categoryVM.Name;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Update(CategoryVM categoryVM) {
            //this.Id = categoryVM.Id;
            this.Name = categoryVM.Name;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Delete() {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }

        public string Name  { get; set; }

        internal void Update(RoleVM roleVM)
        {
            throw new NotImplementedException();
        }
    }
}
