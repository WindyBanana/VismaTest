using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace VismaTest.Models
{
    public class Mission   
    {
        [Key]
        public int MissionID { get; set; }
        [Required]
        public string MissionName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime MissionDate { get; set; }
        public PositionMission PositionMission { get; set; }

    }
}
