using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace VismaTest.Models
{
    public class Task    
    {
        public int TaskID { get; set; }
        [Required]
        public string TaskName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime TaskDate { get; set; }

    }
}
