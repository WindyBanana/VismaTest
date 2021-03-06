using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VismaTest.Models
{
    public class PositionMission
    {
        [Key]
        public int PositionTaskID { get; set; }
        public string PositionTitle { get; set; }
        public string MissionName { get; set; }
        public Position Position { get; set; }
        public Mission Mission { get; set; }
    }
}
