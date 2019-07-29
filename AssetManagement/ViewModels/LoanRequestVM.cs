using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.ViewModels
{
    public class LoanRequestVM
    {
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public LoanRequestVM() { }
        public LoanRequestVM(DateTime? date, string status, int userid)
        {
            this.Date = date;
            this.Status = status;
            this.UserId = userid;
        }
        public void Update(DateTime? date, string status, int userid)
        {
            this.Date = date;
            this.Status = status;
            this.UserId = userid;
        }
    }
}
