using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VismaTest.Models
{
    public class Stilling
    {
        public int StillingID { get; set; }
        [Required]
        public string Stillingstittel { get; set; }
        [DataType(DataType.Date)]
        public DateTime StillingStartDato { get; set; }
        [DataType(DataType.Date)]
        public DateTime StillingSluttDato { get; set; }

        public int AnsattID { get; set; }
        public Ansatt Ansatt { get; set; }
        public ICollection<StillingsOppgave> StillingsOppgaver { get; set; }

    }
}
