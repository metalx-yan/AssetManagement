using AssetManagement.Models;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Repositories.Interfaces
{
    public interface ILoanRequestDetailRepository
    {        
            List<LoanRequestDetail> Get();
            LoanRequestDetail Get(int id);
            List<LoanRequestDetail> Get(string value);
            bool Insert(LoanRequestDetailVM loanrequestdetailVM);
            bool Update(int id, LoanRequestDetailVM loanrequestdetailVM);
            bool Delete(int id);
        
    }
}
