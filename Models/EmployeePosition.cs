using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VismaTest.Models
{
    public class EmployeePosition
    {
        [Key]
        public int EmployeePositionID { get; set; }
        public string PositionTitle { get; set; }
        public string EmployeeName { get; set; }
        public Position Position { get; set; }
        public Employee Employee { get; set; }
    }
}
