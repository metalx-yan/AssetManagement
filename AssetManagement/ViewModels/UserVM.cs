using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.ViewModels
{
    public class UserVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public UserVM() { }
        public UserVM(string email, string password, int roleid)
        {
            this.Email = email;
            this.Password = password;
            this.RoleId = roleid;
        }
        public void Update(string email, string password, int roleid)
        {
            this.Email = email;
            this.Password = password;
            this.RoleId = roleid;
        }
    }
}
