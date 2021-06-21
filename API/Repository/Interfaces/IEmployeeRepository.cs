using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interfaces
{
    interface IEmployeeRepository
    {
        IEnumerable<Employee> Get();
        Employee GetNIK(string nik);

        int Insert(Employee employee);
        int Update(Employee employee, string nik);
        int Delete(string nik);
    }
}
