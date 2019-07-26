using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.ViewModels
{
    public class RoleVM
    {
        public string Name { get; set; }

        //constructor
        public RoleVM() { }
        public RoleVM(string name)
        {
            this.Name = name;
        }

        public void Update(string name)
        {
            //this.Id = id;
            this.Name = name;
        }
    }
}
