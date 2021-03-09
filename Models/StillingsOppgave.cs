namespace VismaTest.Models
{
    public class StillingsOppgave
    {
        public int StillingsOppgaveID { get; set; }
        public int StillingID { get; set; }
        public int OppgaveID { get; set; }
        public Stilling Stilling { get; set; }
        public Oppgave Oppgave { get; set; }

    }
}