using AssetManagement.Core;
using AssetManagement.ViewModels;
using System;

namespace AssetManagement.Models
{
    public class Supplier : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        //parsing
        public Supplier() { }
        public Supplier(SupplierVM supplierVM)
        {
            this.Name = supplierVM.Name;
            this.Email = supplierVM.Email;
            this.Phone = supplierVM.Phone;
            this.Address = supplierVM.Address;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Update(SupplierVM supplierVM)
        {
            this.Name = supplierVM.Name;
            this.Email = supplierVM.Email;
            this.Phone = supplierVM.Phone;
            this.Address = supplierVM.Address;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}