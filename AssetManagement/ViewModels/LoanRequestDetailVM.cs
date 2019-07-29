using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.ViewModels
{
    public class LoanRequestDetailVM
    {
        public int Quantity { get; set; }
        public string AssetName { get; set; }
        public int LoanRequestId { get; set; }
        public LoanRequestDetailVM() { }
        public LoanRequestDetailVM(int quantity, string assetname, int loanrequestid)
        {
            this.Quantity = quantity;
            this.AssetName = assetname;
            this.LoanRequestId = loanrequestid;
        }
        public void Update(int quantity, string assetname, int loanrequestid)
        {
            this.Quantity = quantity;
            this.AssetName = assetname;
            this.LoanRequestId = loanrequestid;
        }
    }
}
