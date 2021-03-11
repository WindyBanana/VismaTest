using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VismaTest.Data;
using VismaTest.Models;

namespace VismaTest.Pages.EmplyeePositions
{
    public class DeleteModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public DeleteModel(VismaTest.Data.VismaTestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmployeePosition EmployeePosition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeePosition = await _context.EmployeePositions.FirstOrDefaultAsync(m => m.EmployeePositionID == id);

            if (EmployeePosition == null)
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

            EmployeePosition = await _context.EmployeePositions.FindAsync(id);

            if (EmployeePosition != null)
            {
                _context.EmployeePositions.Remove(EmployeePosition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
