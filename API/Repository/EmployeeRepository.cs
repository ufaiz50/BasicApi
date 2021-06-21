using API.Context;
using API.Models;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyContext myContext;
        public EmployeeRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        // Melakukan Pengecekan terlebih dahulu Apakah data Dengan NIk employe ada atau tidak
        // Pengecekan Menggunakan FirstOrDefault sehingga kalau tidak ada bisa mengembalikan nilai null atau default
        // Jika datanya tidak ada/ null didalam database maka akan mengembalikan nilai 0
        // Jika ada maka akan dilakukan penghapusan data
        public int Delete(string nik)
        {
            var find = myContext.Employees.FirstOrDefault(e => e.NIK == nik);
            if (find == null) return 0;
            myContext.Employees.Remove(find);
            var delete = myContext.SaveChanges();
            
            return delete;
           
        }

        // Melakukan Pengambilan Data Menggunakan ToList jika tidak ada record data dalam database
        // Maka akan mengembalikan nilai null
        public IEnumerable<Employee> Get()
        {
                var employee = myContext.Employees.ToList();
                if (employee == null) return null;
                return employee;
        }

        // Melakukan Pengambilan Data menggunakan FirstOrDefault karena Jika tidak ada data
        // Maka akan mengembalikan nilai null
        public Employee GetNIK(string nik)
        {
            var getNIK = myContext.Employees.FirstOrDefault(e => e.NIK == nik);
            if(getNIK == null) return null;
            return getNIK;
        }

        // Menambahkan data Employee dengan memeriksa terlebih dahulu
        // Apakah Data dengan NIK Employee yang di input sudah ada di database atau tidak
        // Jika tidak !null atau sudah ada maka akan mengembalikan nilai 0
        // Jika tidak ada maka data employee akan di tambahkan ke dalam database
        public int Insert(Employee employee)
        {
            var isCheck = GetNIK(employee.NIK);
            if(isCheck != null) return 0;
            myContext.Employees.Add(employee);
            var insert = myContext.SaveChanges();
            return insert;
            
        }

        // Melakukan Pemeriksaan Terlebih dahulu apakah data dengan NIK tersebut ada di database atau tidak
        // Jika data tidak ada maka akan mengembalikan nilai int 0
        // Jika data ada maka akan dilakukan update
        public int Update(Employee employee, string nik)
        {
            var emp = myContext.Employees.SingleOrDefault(e => e.NIK == nik);
            if (emp == null) return 0;

            if (employee.FirstName != null) emp.FirstName = employee.FirstName;
            if (employee.LastName != null) emp.LastName = employee.LastName;
            if (employee.Email != null) emp.Email = employee.Email;
            if (employee.Salary != 0) emp.Salary = employee.Salary;
            if (employee.PhoneNumber != null) emp.PhoneNumber = employee.PhoneNumber;
            if (employee.BirthDate != null) emp.BirthDate = employee.BirthDate;

            myContext.Entry(emp).State = EntityState.Modified;
            var update = myContext.SaveChanges();
            return update;
        }
    }
}
