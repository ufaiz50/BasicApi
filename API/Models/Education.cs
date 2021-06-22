﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("tb_M_Education")]
    public class Education
    {
        public Education()
        {
        }

        [Key]
        public int Id { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public int UniversityId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Profilling> Profilling { get; set; }

        [JsonIgnore]
        public virtual University University { get; set; }

        public Education(string degree, string gPA, int UniversityId)
        {
            Degree = degree;
            GPA = gPA;
            this.UniversityId = UniversityId;
        }
    }
}
