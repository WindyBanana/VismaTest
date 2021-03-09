using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VismaTest.Data;
using VismaTest.Models;

namespace VismaTest.Pages.StillingsOppgaver
{
    public class EditModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public EditModel(VismaTest.Data.VismaTestContext context)
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
           ViewData["OppgaveID"] = new SelectList(_context.Oppgave, "OppgaveID", "OppgaveNavn");
           ViewData["StillingID"] = new SelectList(_context.Stilling, "StillingID", "Stillingstittel");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StillingsOppgave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StillingsOppgaveExists(StillingsOppgave.StillingsOppgaveID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StillingsOppgaveExists(int id)
        {
            return _context.StillingsOppgave.Any(e => e.StillingsOppgaveID == id);
        }
    }
}
