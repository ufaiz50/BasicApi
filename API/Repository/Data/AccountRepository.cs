using API.Context;
using API.Models;
using API.Repository.Interfaces;
using API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext myContext;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int Login(LoginVM login)
        {
            var checkNIK = myContext.Accounts.FirstOrDefault(a => a.NIK == login.NIK || a.Employee.Email == login.NIK);
            if (checkNIK == null) return 2;
            return checkNIK.Password == login.password ? 1 : 3;
        }
    }
}
