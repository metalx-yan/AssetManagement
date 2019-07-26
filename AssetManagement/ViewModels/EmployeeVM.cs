using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.ViewModels
{
    public class EmployeeVM
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public EmployeeVM() { }
        public EmployeeVM(string name, string department, string address)
        {
            this.Name = name;
            this.Department = department;
            this.Address = address;
        }
        public void Update(string name, string department, string address)
        {
            this.Name = name;
            this.Department = department;
            this.Address = address;
        }
    }
}
