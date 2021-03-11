using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VismaTest.Models
{
    public class Employee
    {   [Key]
        public int EmployeeID { get; set; }
        
        [Required]
        public string EmployeeName { get; set; }
        public Position Position { get; set; }
        public IList<Position> Positions { get; set; }

    }
}

