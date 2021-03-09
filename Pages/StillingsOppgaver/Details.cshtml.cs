using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VismaTest.Data;
using VismaTest.Models;

namespace VismaTest.Pages.StillingsOppgaver
{
    public class DetailsModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public DetailsModel(VismaTest.Data.VismaTestContext context)
        {
            _context = context;
        }

        public StillingsOppgave StillingsOppgave { get; set; }
        public Ansatt Ansatt { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StillingsOppgave = await _context.StillingsOppgave
                .Include(s => s.Oppgave)
                .Include(s => s.Stilling).FirstOrDefaultAsync(m => m.StillingsOppgaveID == id);
            
            
            if (StillingsOppgave == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
