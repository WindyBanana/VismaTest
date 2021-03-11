using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VismaTest.Data;
using VismaTest.Models;

namespace VismaTest.Pages.EmplyeePositions
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
            ViewData["EmployeeName"] = new SelectList(_context.Employees, "EmployeeName", "EmployeeName");
            ViewData["PositionTitle"] = new SelectList(_context.Positions, "PositionTitle", "PositionTitle");
            return Page();
        }

        [BindProperty]
        public EmployeePosition EmployeePosition { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EmployeePositions.Add(EmployeePosition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
