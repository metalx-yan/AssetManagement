using AssetManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.ViewModels
{
    public class SupplierVM 
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        //parsing

        public SupplierVM() { }

        public SupplierVM(string Name, string Email, string Phone, string Address)
        {
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
        }

        public void Update(string Name, string Email, string Phone, string Address)
        {
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
        }
    }
}
