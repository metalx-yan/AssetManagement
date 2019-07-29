using AssetManagement.Models;
using AssetManagement.Repositories;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Controllers
{
    public class LoanRequestDetailsController
    {
        ILoanRequestDetailRepository iloanrequestdetailrepository = new LoanRequestDetailRepository();
        public List<LoanRequestDetail> Get()
        {
            return iloanrequestdetailrepository.Get();
        }
        public LoanRequestDetail Get(int id)
        {
            return iloanrequestdetailrepository.Get(id);
        }
        public List<LoanRequestDetail> Get(string value)
        {
            return iloanrequestdetailrepository.Get(value);
        }
        public bool Insert(LoanRequestDetailVM loanrequestdetailVM)
        {
            return iloanrequestdetailrepository.Insert(loanrequestdetailVM);
        }
        public bool Update(int id, LoanRequestDetailVM loanrequestdetailVM)
        {
            return iloanrequestdetailrepository.Update(id, loanrequestdetailVM);
        }
        public bool Delete(int id)
        {
            return iloanrequestdetailrepository.Delete(id);
        }
    }
}
