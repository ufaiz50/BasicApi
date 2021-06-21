using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interfaces
{
    interface IUniversityRepository
    {
        IEnumerable<University> Get();
        University GetId(int id);
        int Insert(University university);
        int Update(University university, int id);
        int Delete(int id);
    }
}
