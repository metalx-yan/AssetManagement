using AssetManagement.Core;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Models
{
    public class LoanRequest : BaseModel
    {
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public User User{ get; set; }
        public LoanRequest() { }
        public LoanRequest(LoanRequestVM loanrequestVM)
        {
            this.Date = loanrequestVM.Date;
            this.Status = loanrequestVM.Status;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Update(LoanRequestVM loanrequestVM)
        {
            this.Date = loanrequestVM.Date;
            this.Status = loanrequestVM.Status;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }

    }
}
