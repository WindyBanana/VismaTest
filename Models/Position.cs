using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VismaTest.Models
{
    public class Position
    {
        public int PositionID { get; set; }
        [Required]
        public string PositionTitle { get; set; }
        [DataType(DataType.Date)]
        public DateTime PositionStartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime PositionEndDate { get; set; }

        public PositionTask PositionTask { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
