using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.ViewModels
{
    public class EmployeeVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender{ get; set; }
        public string Religion { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public int ManagerId { get; set; }
        public EmployeeVM() { }
        public EmployeeVM(string firstname, string lastname, bool gender, string religion, string department, string address, int managerid)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Gender = gender;
            this.Religion = religion;
            this.Department = department;
            this.Address = address;
            this.ManagerId = managerid;
        }
        public void Update(string firstname, string lastname, bool gender, string religion, string department, string address, int managerid)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Gender = gender;
            this.Religion = religion;
            this.Department = department;
            this.Address = address;
            this.ManagerId = managerid;
        }
    }
}
