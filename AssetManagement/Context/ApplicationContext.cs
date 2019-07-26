using AssetManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Context
{
    //context untuk menghubungkan aplikasi dengan database
    //controller mengatur proses dari setiap module(alur data program ada di controller)
    //core buat satu file basis untuk primari key
    // model adalah representasi dari database
    // cara codefirst dan database first
    // repositories dari view ke kontroller repository baru model
    // view model adalah penampung nilai
    public class ApplicationContext : DbContext
    {
        // buat constructor, penamaan adalah nama class
        public ApplicationContext() : base("AssetManagement") { }

        // Categories adalah nama objek
        public DbSet<Category> Categories { set; get; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<Employee> Employees{ set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<LoanRequest> LoanRequests { set; get; }
    }
}
