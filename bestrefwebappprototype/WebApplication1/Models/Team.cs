using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    public class Team
    {
            [DataMember]
            [Key]
            public int team_id { get; set; }
            public string team_name { get; set; }
            public string team_coach_first_name { get; set; }
            public string team_coach_last_name { get; set; }

    }
}