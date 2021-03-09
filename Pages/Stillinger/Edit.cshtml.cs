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

namespace VismaTest.Pages.Stillinger
{
    public class EditModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public EditModel(VismaTest.Data.VismaTestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stilling Stilling { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stilling = await _context.Stilling
                .Include(s => s.Ansatt).FirstOrDefaultAsync(m => m.StillingID == id);

            if (Stilling == null)
            {
                return NotFound();
            }
           ViewData["AnsattID"] = new SelectList(_context.Ansatt, "AnsattID", "AnsattNavn");
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

            _context.Attach(Stilling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StillingExists(Stilling.StillingID))
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

        private bool StillingExists(int id)
        {
            return _context.Stilling.Any(e => e.StillingID == id);
        }
    }
}
