using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VismaTest.Models
{
    public class Position
    {
        [Key]
        public int PositionID { get; set; }
        [Required]
        public string PositionTitle { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PositionStartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PositionEndDate { get; set; }
        public PositionMission PositionMission { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
