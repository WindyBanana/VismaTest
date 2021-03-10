using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VismaTest.Models
{
    public class PositionTask
    {
        [Key]
        public int PositionTaskID { get; set; }
        public int PositionName { get; set; }
        public int TaskName { get; set; }

        public Position Position { get; set; }
        public Task Task { get; set; }
    }
}
