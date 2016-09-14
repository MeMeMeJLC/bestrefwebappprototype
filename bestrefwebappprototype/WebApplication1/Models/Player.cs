using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    public class Player
    {
        [DataMember]
        [Key]
        public int player_id { get; set; }
        public int team_id { get; set; }
        public string team_name { get; set; }
        public string player_firstname { get; set; }
        public string player_lastname { get; set; }
        public int player_number { get; set; }
    }
}