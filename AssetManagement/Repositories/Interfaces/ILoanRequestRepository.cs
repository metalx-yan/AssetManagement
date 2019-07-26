using AssetManagement.Models;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Repositories.Interfaces
{
    public interface ILoanRequestRepository
    {
        List<LoanRequest> Get();
        LoanRequest Get(int id);
        List<LoanRequest> Get(string value);
        bool Insert(LoanRequestVM loanrequestVM);
        bool Update(int id,LoanRequestVM loanrequestVM);
        bool Delete(int id);
    }
}
