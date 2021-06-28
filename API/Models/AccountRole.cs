using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("tb_T_AccountRole")]
    public class AccountRole
    {
        public AccountRole()
        {
        }

        public int AccountRoleId { get; set; }
        public string AccountNIK { get; set; }
        public int RoleId { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }

        public AccountRole(string accountNIk, int roleId)
        {
            AccountNIK = accountNIk;
            RoleId = roleId;
        }
    }
}
