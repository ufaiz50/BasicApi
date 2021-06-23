using API.Context;
using API.Models;
using API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>
    {
        private readonly MyContext myContext;
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int Register(RegisterVM register)
        {
            var isChek = myContext.Employees.Find(register.NIK);
            if (isChek != null) return 2;
            var checkEmail = myContext.Employees.FirstOrDefault(e => e.Email == register.email);
            if (checkEmail != null) return 3;

            //generate password
            var getPassword = Hashing.Hashing.HashPassword(register.password);

            Employee employee = new Employee(register.NIK, register.firstname, register.lastname
                , register.email, register.salary, register.phoneNumber, register.birthdate, register.gender);
            
            Account account = new Account(register.NIK, getPassword);

            Education education = new Education(register.degree, register.GPA, register.UniversityId);
            Profilling profilling = new Profilling(register.NIK, education);
            //profilling.education = education;

            myContext.Employees.Add(employee);
            myContext.Accounts.Add(account);
            myContext.Profillings.Add(profilling);
            myContext.Educations.Add(education);
            var insert = myContext.SaveChanges();
            return insert;
            
        }

        public int Login(LoginVM login)
        {
            var checkNIK = myContext.Employees.FirstOrDefault(e => e.NIK == login.NIK || e.Email == login.NIK);
            if (checkNIK == null) return 2;
            return checkNIK.account.Password == login.password ? 1 : 3;
        }

    }
}
