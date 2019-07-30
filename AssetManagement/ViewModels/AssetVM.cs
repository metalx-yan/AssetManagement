using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.ViewModels
{
    public class AssetVM
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public int SerialKey { get; set; }
        public string Spesification { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public AssetVM() { }
        public AssetVM(string Name, int Stock, int SerialKey, string Spesification, int supplierid, int categoryid)
        {
            this.Name = Name;
            this.Stock = Stock;
            this.SerialKey = SerialKey;
            this.Spesification = Spesification;
            this.SupplierId = supplierid;
            this.CategoryId = categoryid;
        }
        public void Update(string Name, int Stock, int SerialKey, string Spesification, int supplierid,  int categoryid)
        {
            this.Name = Name;
            this.Stock = Stock;
            this.SerialKey = SerialKey;
            this.Spesification = Spesification;
            this.SupplierId = supplierid;
            this.CategoryId = categoryid;
        }
    }
}
