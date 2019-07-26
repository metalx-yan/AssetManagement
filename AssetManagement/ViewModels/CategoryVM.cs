using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.ViewModels
{
    public class CategoryVM
    {
        // merepresentasikan model yang ada di view, inputan yang ada di view ada di vm
        //public int Id { get; set; }
        public string Name { get; set; }

        //constructor
        public CategoryVM() { }
        public CategoryVM(string name)
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
