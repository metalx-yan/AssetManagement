using AssetManagement.Core;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class LoanRequestDetail : BaseModel
    {
        public int Quantity { get; set; }
        public string AssetName { get; set; }
        public LoanRequest LoanRequest { get; set; }
        public LoanRequestDetail() { }
        public LoanRequestDetail(LoanRequestDetailVM loanrequestdetailVM)
        {
            this.Quantity = loanrequestdetailVM.Quantity;
            this.AssetName = loanrequestdetailVM.AssetName;
            //this.Role_Id = userVM.Role_Id;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Update(LoanRequestDetailVM loanrequestdetailVM)
        {
            this.Quantity = loanrequestdetailVM.Quantity;
            this.AssetName = loanrequestdetailVM.AssetName;
            //this.Role = Convert.ToInt32(userVM.RoleId);
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
