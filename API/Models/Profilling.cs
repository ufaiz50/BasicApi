﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("tb_M_Profilling")]
    public class Profilling
    {
        [Key]
        public string NIK { get; set; }
        public int EducationId { get; set; }

        [JsonIgnore]
        public virtual Account account { get; set; }
        [JsonIgnore]
        public virtual Education education { get; set; }

    }
}