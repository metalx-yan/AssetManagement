using AssetManagement.Core;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class Return : BaseModel
    {
        public DateTime? ReturnDate { get; set; }
        public int TotalFine { get; set; }

        public Return() { }

        public Return(ReturnVM returnVM)
        {
            this.ReturnDate = returnVM.ReturnDate;
            this.TotalFine = returnVM.TotalFine;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Update(ReturnVM returnVM)
        {
            this.ReturnDate = returnVM.ReturnDate;
            this.TotalFine = returnVM.TotalFine;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
