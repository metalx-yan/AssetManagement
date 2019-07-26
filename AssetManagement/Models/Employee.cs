using AssetManagement.Core;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class Employee : BaseModel
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public Employee() { }
        public Employee(EmployeeVM employeeVM)
        {
            this.Name = employeeVM.Name;
            this.Department = employeeVM.Department;
            this.Address = employeeVM.Address;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Update(EmployeeVM employeeVM)
        {
            this.Name = employeeVM.Name;
            this.Department = employeeVM.Department;
            this.Address = employeeVM.Address;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }        

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
