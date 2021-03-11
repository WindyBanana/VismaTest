using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VismaTest.Data;
using VismaTest.Models;

namespace VismaTest.Pages.PositionMissions
{
    public class DeleteModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public DeleteModel(VismaTest.Data.VismaTestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PositionMission PositionMission { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PositionMission = await _context.PosiotionMissions.FirstOrDefaultAsync(m => m.PositionTaskID == id);

            if (PositionMission == null)
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

            PositionMission = await _context.PosiotionMissions.FindAsync(id);

            if (PositionMission != null)
            {
                _context.PosiotionMissions.Remove(PositionMission);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
