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

namespace VismaTest.Pages.PositionMissions
{
    public class EditModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public EditModel(VismaTest.Data.VismaTestContext context)
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
            ViewData["PositionTitle"] = new SelectList(_context.Positions, "PositionTitle", "PositionTitle");
            ViewData["MissionName"] = new SelectList(_context.Missions, "MissionName", "MissionName");
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

            _context.Attach(PositionMission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionMissionExists(PositionMission.PositionTaskID))
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

        private bool PositionMissionExists(int id)
        {
            return _context.PosiotionMissions.Any(e => e.PositionTaskID == id);
        }
    }
}
