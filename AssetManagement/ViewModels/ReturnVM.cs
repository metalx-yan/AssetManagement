using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.ViewModels
{
    public class ReturnVM
    {
        public DateTime? ReturnDate { get; set; }
        public int TotalFine { get; set; }

        public ReturnVM() { }

        public ReturnVM(DateTime? ReturnDate, int TotalFine)
        {
            this.ReturnDate = ReturnDate;
            this.TotalFine = TotalFine;
        }

        public void Update(DateTime? ReturnDate, int TotalFine)
        {
            this.ReturnDate = ReturnDate;
            this.TotalFine = TotalFine;
        }
    }
}
