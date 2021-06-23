using API.Context;
using API.Models;
using API.Repository.Interfaces;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            var genValidation = Hashing.Hashing.ValidatePassword(login.password, checkNIK.Password);
            return genValidation ? 1 : 3;
        }

        public int UpdatePassword(UpdatePasswordVM updatePassword)
        {
            var acc = myContext.Accounts.SingleOrDefault(a => a.NIK == updatePassword.NIK || a.Employee.Email == updatePassword.NIK);
            if (acc == null) return 0;

            var checkPassword = Hashing.Hashing.ValidatePassword(updatePassword.OldPassword, acc.Password);
            if (!checkPassword) return 2;

            var getPassword = Hashing.Hashing.HashPassword(updatePassword.NewPassword);

            acc.Password = getPassword;


            myContext.Entry(acc).State = EntityState.Modified;
            var update = myContext.SaveChanges();
            return update;
        }

        public int ResetPassword(ResetPasswordVM reset)
        {
            var check = myContext.Accounts.FirstOrDefault(a => a.NIK == reset.NIK || a.Employee.Email == reset.NIK);
            if (check == null) return 0;

            var getGUID = Hashing.Hashing.GetGUID();
            var getPassword = Hashing.Hashing.HashPassword(getGUID);
            check.Password = getPassword;

            myContext.Entry(check).State = EntityState.Modified;
            var resetPass = myContext.SaveChanges();

            Hashing.SendEmail.Receive(check, getGUID);

            return resetPass;
        }
    }
}
