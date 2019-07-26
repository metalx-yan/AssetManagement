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
        public bool Status { get; set; }
        public LoanRequestVM() { }
        public LoanRequestVM(DateTime? date, bool status)
        {
            this.Date = date;
            this.Status = status;
        }
        public void Update(DateTime? date, bool status)
        {
            this.Date = date;
            this.Status = status;
        }
    }
}
