using AssetManagement.Core;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class Asset : BaseModel
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public int SerialKey { get; set; }
        public string Spesification { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }
        //parsing
        public Asset() { }
        public Asset(AssetVM assetVM)
        {
            this.Name = assetVM.Name;
            this.Stock = assetVM.Stock;
            this.SerialKey = assetVM.SerialKey;
            this.Spesification = assetVM.Spesification;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Update(AssetVM assetVM)
        {
            this.Name = assetVM.Name;
            this.Stock = assetVM.Stock;
            this.SerialKey = assetVM.SerialKey;
            this.Spesification = assetVM.Spesification;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
