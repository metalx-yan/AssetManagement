using AssetManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagement.Models;
using AssetManagement.ViewModels;
using AssetManagement.Context;
using System.Data.Entity;

namespace AssetManagement.Repositories
{
    public class LoanRequestRepository : ILoanRequestRepository
    {
        ApplicationContext applicationcontext = new ApplicationContext();
        bool status = true;

        public bool Delete(int id)
        {
            var get = Get(id);
            get.Delete();
            applicationcontext.Entry(get).State = EntityState.Modified;
            var result = applicationcontext.SaveChanges();
            return result > 0;
        }
        public List<LoanRequest> Get()
        {
            var get = applicationcontext.LoanRequests.Where(x => x.IsDelete == false).Include("User").ToList();
            return get;
        }
        public List<LoanRequest> Get(string value)
        {
            var get = applicationcontext.LoanRequests.Where(x => Convert.ToString(x.Date).Contains(value) || x.IsDelete == false).ToList();
            return get;
        }
        public LoanRequest Get(int id)
        {
            var get = applicationcontext.LoanRequests.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }
        public bool Insert(LoanRequestVM loanrequestVM)
        {
            var push = new LoanRequest(loanrequestVM);
            if (push != null)
            {
                var getUser = applicationcontext.Users.SingleOrDefault(x => x.IsDelete == false && x.Id == loanrequestVM.UserId);
                push.User = getUser;
                applicationcontext.LoanRequests.Add(push);
                var result = applicationcontext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }           
        }
        public bool Update(int id,LoanRequestVM loanrequestVM)
        {
            var get = Get(id);
            if (get != null)
            {
                var getUser = applicationcontext.Users.SingleOrDefault(x => x.IsDelete == false && x.Id == loanrequestVM.UserId);
                get.User = getUser;
                get.Update(loanrequestVM);
                applicationcontext.Entry(get).State = EntityState.Modified;
                var result = applicationcontext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
            
        }
    }
}
