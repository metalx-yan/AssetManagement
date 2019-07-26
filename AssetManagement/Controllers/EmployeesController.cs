using AssetManagement.Models;
using AssetManagement.Repositories;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Controllers
{
    public class EmployeesController
    {
        IEmployeeRepository iemployeerepository = new EmployeeRepository();
        public List<Employee> Get()
        {
            return iemployeerepository.Get();
        }
        public Employee Get(int id)
        {
            return iemployeerepository.Get(id);
        }
        public List<Employee> Get(string value)
        {
            return iemployeerepository.Get(value);
        }
        public bool Insert(EmployeeVM employeeVM)
        {
            return iemployeerepository.Insert(employeeVM);
        }
        public bool Update(int id, EmployeeVM employeeVM)
        {
            return iemployeerepository.Update(id,employeeVM);
        }
        public bool Delete(int id)
        {
            return iemployeerepository.Delete(id);
        }
    }
}
