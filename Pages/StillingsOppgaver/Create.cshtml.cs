using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VismaTest.Data;
using VismaTest.Models;

namespace VismaTest.Pages.StillingsOppgaver
{
    public class CreateModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public CreateModel(VismaTest.Data.VismaTestContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OppgaveID"] = new SelectList(_context.Oppgave, "OppgaveID", "OppgaveNavn");
        ViewData["StillingID"] = new SelectList(_context.Stilling, "StillingID", "Stillingstittel");
            return Page();
        }

        [BindProperty]
        public StillingsOppgave StillingsOppgave { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StillingsOppgave.Add(StillingsOppgave);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
