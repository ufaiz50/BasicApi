using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("tb_M_Account")]
    public class Account
    {
        [Key]
        public string NIK { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public virtual Employee Employee { get; set; }
        [JsonIgnore]
        public virtual Profilling Profilling { get; set; }
        //[JsonIgnore]
        public virtual ICollection<AccountRole> AccountRole { get; set; }


        public Account(string nIK, string password)
        {
            NIK = nIK;
            Password = password;
                        
        }

        public Account()
        {
        }
    }
    
}
