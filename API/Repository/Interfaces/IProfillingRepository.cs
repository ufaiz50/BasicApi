using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interfaces
{
    interface IProfillingRepository
    {
        IEnumerable<Profilling> Get();
        Profilling GetNIK(int nik);
        int Insert(Profilling profilling);
        int Update(Profilling profilling, string nik);
        int Delete(string nik);
    }
}
