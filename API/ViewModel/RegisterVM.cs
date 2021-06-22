using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class RegisterVM
    {
        public string NIK { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phoneNumber { get; set; }

        public DateTime birthdate { get; set; }
        public Gender gender { get; set; }
        public int salary { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string degree { get; set; }
        public string GPA { get; set; }
        public int UniversityId { get; set; }
    }
}
