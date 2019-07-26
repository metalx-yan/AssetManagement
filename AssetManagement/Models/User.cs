using AssetManagement.Core;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class User : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public User() { }
        public User(UserVM userVM)
        {
            this.Email = userVM.Email;
            this.Password = userVM.Password;
            //this.Role_Id = userVM.Role_Id;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Update(UserVM userVM)
        {
            this.Email = userVM.Email;
            this.Password = userVM.Password;
            //this.Role_Id = userVM.Role_Id;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
