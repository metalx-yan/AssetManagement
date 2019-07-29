using AssetManagement.Context;
using AssetManagement.Models;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Repositories
{
    public class LoanRequestDetailRepository : ILoanRequestDetailRepository
    {
        bool status = false;

        ApplicationContext applicationcontext = new ApplicationContext();
        public bool Delete(int id)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Delete();
                applicationcontext.Entry(get).State = EntityState.Modified;
                var result = applicationcontext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
        }
        public List<LoanRequestDetail> Get()
        {
            // Categories yang ada di applicationcontext
            var get = applicationcontext.LoanRequestDetails.Where(x => x.IsDelete == false).Include("LoanRequest").ToList();
            return get;
        }
        public List<LoanRequestDetail> Get(string value)
        {
            //var c = Convert.ToInt32(value);
            // contains artinya mengandung value yang ada di colom
            var get = applicationcontext.LoanRequestDetails.Where(x => (x.AssetName.Contains(value) || Convert.ToString(x.Id).Contains(value)) && x.IsDelete == false).ToList();
            return get;
        }

        public LoanRequestDetail Get(int id)
        {
            // var get = applicationcontext.Categories.Where(x => x.IsDelete == false && x.Id == id).SingleOrDefault();
            var get = applicationcontext.LoanRequestDetails.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(LoanRequestDetailVM loanrequestdetailVM)
        {
            var push = new LoanRequestDetail(loanrequestdetailVM);
            if (push != null)
            {
                var getLoanRequest = applicationcontext.LoanRequests.SingleOrDefault(x => x.IsDelete == false && x.Id == loanrequestdetailVM.LoanRequestId);
                push.LoanRequest = getLoanRequest;
                applicationcontext.LoanRequestDetails.Add(push);
                var result = applicationcontext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
        }
        public bool Update(int id, LoanRequestDetailVM loanrequestdetailVM)
        {
            var get = Get(id);
            if (get != null)
            {
                var getLoanRequest = applicationcontext.LoanRequests.SingleOrDefault(x => x.IsDelete == false && x.Id == loanrequestdetailVM.LoanRequestId);
                get.LoanRequest = getLoanRequest;
                get.Update(loanrequestdetailVM);
                // entry data yang akan di ubah, state mengacu sebelah kanan supaya kita mendapatkan modified
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
