using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("tb_M_Employee")]
    public class Employee
    {
        public Employee()
        {
        }

        [Key]
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }

        [JsonIgnore]
        public virtual Account account { get; set; }

        public Employee(string nIK, string firstName, string lastName, string email, int salary, string phoneNumber, DateTime birthDate, Gender gender)
        {
            NIK = nIK;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Salary = salary;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Gender = gender;
        }
    }

    public enum Gender
    {
        Pria,
        Wanita
    }
}
