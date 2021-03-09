using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VismaTest.Data;
using VismaTest.Models;

namespace VismaTest.Pages.Stillinger
{
    public class DeleteModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public DeleteModel(VismaTest.Data.VismaTestContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stilling = await _context.Stilling.FindAsync(id);

            if (Stilling != null)
            {
                _context.Stilling.Remove(Stilling);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
