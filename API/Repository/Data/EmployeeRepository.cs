using API.Context;
using API.Models;
using API.ViewModel;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
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
            var getPassword = Jwt.Hashing.HashPassword(register.password);

            Employee employee = new Employee(register.NIK, register.firstname, register.lastname
                , register.email, register.salary, register.phoneNumber, register.birthdate, register.gender);
            
            AccountRole ar = new AccountRole(register.NIK, 1);
            Account account = new Account(register.NIK, getPassword);
            

            

            Education education = new Education(register.degree, register.GPA, register.UniversityId);
            Profilling profilling = new Profilling(register.NIK, education);

            myContext.Employees.Add(employee);
            myContext.Accounts.Add(account);
            myContext.AccountRoles.Add(ar);
            myContext.Profillings.Add(profilling);
            myContext.Educations.Add(education);
            var insert = myContext.SaveChanges();
            return insert;
            
        }

        public IEnumerable ShowData()
        {

            var data = from em in myContext.Employees
                         join acc in myContext.Accounts on em.NIK equals acc.NIK
                         join accrole in myContext.AccountRoles on acc.NIK equals accrole.AccountNIK
                         join role in myContext.Roles on accrole.RoleId equals role.RoleId
                         join prof in myContext.Profillings on acc.NIK equals prof.NIK
                         join edu in myContext.Educations on prof.EducationId equals edu.Id
                         join uni in myContext.Universities on edu.UniversityId equals uni.UniversityId
                        select new
                        {
                            em.NIK,
                            em.FirstName,
                            em.LastName,
                            em.Email,
                            em.Salary,
                            em.PhoneNumber,
                            em.BirthDate,
                            em.Gender,
                            accrole.RoleId,
                            edu.Degree,
                            edu.GPA,
                            uni.UniversityName
                        };
            return data;
        }

        public IEnumerable ShowDataByNIK(string NIK)
        {
            var check = myContext.Employees.FirstOrDefault(e => e.NIK == NIK || e.Email == NIK );
            if (check == null) return null;
            var data = from em in myContext.Employees
                       join acc in myContext.Accounts on em.NIK equals acc.NIK
                       join accrole in myContext.AccountRoles on acc.NIK equals accrole.AccountNIK
                       join role in myContext.Roles on accrole.RoleId equals role.RoleId
                       join prof in myContext.Profillings on acc.NIK equals prof.NIK
                       join edu in myContext.Educations on prof.EducationId equals edu.Id
                       join uni in myContext.Universities on edu.UniversityId equals uni.UniversityId
                       where em.NIK == NIK || em.Email == NIK
                       select new 
                        {
                            em.NIK,
                            em.FirstName,
                            em.LastName,
                            em.Email,
                            em.Salary,
                            em.PhoneNumber,
                            em.BirthDate,
                            em.Gender,
                            role.RoleName,
                            edu.Degree,
                            edu.GPA,
                            uni.UniversityName
                        };

            return data;
        }
    }
}
