using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace VismaTest.Models
{
    public class Oppgave    
    {
        public int OppgaveID { get; set; }
        [Required]
        public string OppgaveNavn { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime OppgaveDato { get; set; }

    }
}
