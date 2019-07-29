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
    public class LoanRequestsController
    {
        ILoanRequestRepository iloanrequestrepository = new LoanRequestRepository();
        public List<LoanRequest> Get()
        {
            return iloanrequestrepository.Get();
        }
        public LoanRequest Get(int id)
        {
            return iloanrequestrepository.Get(id);
        }
        //search
        public List<LoanRequest> Get(string value)
        {
            return iloanrequestrepository.Get(value);
        }
        // categoryVM adalah object
        public bool Insert(LoanRequestVM loanrequestVM)
        {
            return iloanrequestrepository.Insert(loanrequestVM);
        }
        public bool Update(int id, LoanRequestVM loanrequestVM)
        {
            return iloanrequestrepository.Update(id, loanrequestVM);
        }
        public bool Delete(int id)
        {
            return iloanrequestrepository.Delete(id);
        }
    }
}
