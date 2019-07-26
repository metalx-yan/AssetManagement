using AssetManagement.Context;
using AssetManagement.Models;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Repositories
{
    //kenapa implement kaya gini
    public class EmployeeRepository : IEmployeeRepository
    {
        bool status = false;
        ApplicationContext applicationcontext = new ApplicationContext();
        public bool Delete(int id)
        {
            var get = Get(id);
            get.Delete();
            applicationcontext.Entry(get).State = EntityState.Modified;
            var result = applicationcontext.SaveChanges();
            return result > 0;
        }
        public List<Employee> Get()
        {
            var get = applicationcontext.Employees.Where(x => x.IsDelete == false).ToList();
            return get;
        }
        public List<Employee> Get(string value)
        {
            var get = applicationcontext.Employees.Where(x => (x.Name.Contains(value) || Convert.ToString(value).Contains(value)) && x.IsDelete == false).ToList();
            return get;
        }
        public Employee Get(int id)
        {
            var get = applicationcontext.Employees.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }
        //dapet dari mana ini
        public bool Insert(EmployeeVM employeeVM)
        {
            var push = new Employee(employeeVM);
            applicationcontext.Employees.Add(push);
            var result = applicationcontext.SaveChanges();
            return result > 0;
        }
        public bool Update(int id, EmployeeVM employeeVM)
        {
            var get = Get(id);
            get.Update(employeeVM);
            applicationcontext.Entry(get).State = EntityState.Modified;
            var result = applicationcontext.SaveChanges();
            return result > 0;
        }
    }
}
