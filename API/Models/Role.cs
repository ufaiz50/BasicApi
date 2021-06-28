using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("tb_M_Role")]
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        [JsonIgnore]
        public virtual ICollection<AccountRole> AccountRole { get; set; }
    }
}
