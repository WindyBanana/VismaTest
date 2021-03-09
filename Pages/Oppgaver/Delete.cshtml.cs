using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VismaTest.Data;
using VismaTest.Models;

namespace VismaTest.Pages.Oppgaver
{
    public class DeleteModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public DeleteModel(VismaTest.Data.VismaTestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Oppgave Oppgave { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Oppgave = await _context.Oppgave.FirstOrDefaultAsync(m => m.OppgaveID == id);

            if (Oppgave == null)
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

            Oppgave = await _context.Oppgave.FindAsync(id);

            if (Oppgave != null)
            {
                _context.Oppgave.Remove(Oppgave);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
