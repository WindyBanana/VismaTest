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
    public class DeleteModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public DeleteModel(VismaTest.Data.VismaTestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StillingsOppgave StillingsOppgave { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StillingsOppgave = await _context.StillingsOppgave.FindAsync(id);

            if (StillingsOppgave != null)
            {
                _context.StillingsOppgave.Remove(StillingsOppgave);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
