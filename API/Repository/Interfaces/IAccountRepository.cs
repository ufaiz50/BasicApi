using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interfaces
{
    interface IAccountRepository
    {
        IEnumerable<Account> Get();
        Account GetNIK(string nik);
        int Insert(Account account);
        int Update(Account account, string nik);
        int Delete(string nik);
    }
}
