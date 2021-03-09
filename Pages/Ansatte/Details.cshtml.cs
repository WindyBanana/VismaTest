using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VismaTest.Data;
using VismaTest.Models;

namespace VismaTest.Pages.Ansatte
{
    public class DetailsModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public DetailsModel(VismaTest.Data.VismaTestContext context)
        {
            _context = context;
        }

        public Ansatt Ansatt { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ansatt = await _context.Ansatt.FirstOrDefaultAsync(m => m.AnsattID == id);

            if (Ansatt == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
