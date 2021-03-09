using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VismaTest.Models
{
    public class Ansatt
    {
        public int AnsattID { get; set; }
        
        [Index(IsUnique = true)]
        [Required]
        public string AnsattNavn { get; set; }
        public ICollection<Stilling> Stillinger { get; set; }

    }
}

