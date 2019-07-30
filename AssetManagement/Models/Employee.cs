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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string Religion { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public Employee Manager { get; set; }
        public Employee() { }
        public Employee(EmployeeVM employeeVM)
        {
            this.FirstName = employeeVM.FirstName;
            this.LastName = employeeVM.LastName;
            this.Gender = employeeVM.Gender;
            this.Religion = employeeVM.Religion;
            this.Department = employeeVM.Department;
            this.Address = employeeVM.Address;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Update(EmployeeVM employeeVM)
        {
            this.FirstName = employeeVM.FirstName;
            this.LastName = employeeVM.LastName;
            this.Gender = employeeVM.Gender;
            this.Religion = employeeVM.Religion;
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
