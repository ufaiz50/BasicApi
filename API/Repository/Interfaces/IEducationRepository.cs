using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interfaces
{
    interface IEducationRepository
    {
        IEnumerable<Education> Get();
        Education GetNIK(string id);
        int Insert(Education education);
        int Update(Education education, string id);
        int Delete(string id);
    }
}
