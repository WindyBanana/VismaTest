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

namespace VismaTest.Pages.EmplyeePositions
{
    public class EditModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public EditModel(VismaTest.Data.VismaTestContext context)
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
            ViewData["EmployeeName"] = new SelectList(_context.Employees, "EmployeeName", "EmployeeName");
            ViewData["PositionTitle"] = new SelectList(_context.Positions, "PositionTitle", "PositionTitle");
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

            _context.Attach(EmployeePosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeePositionExists(EmployeePosition.EmployeePositionID))
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

        private bool EmployeePositionExists(int id)
        {
            return _context.EmployeePositions.Any(e => e.EmployeePositionID == id);
        }
    }
}
