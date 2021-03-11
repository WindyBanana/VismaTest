using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VismaTest.Data;
using VismaTest.Models;

namespace VismaTest.Pages.Missions
{
    public class DetailsModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public DetailsModel(VismaTest.Data.VismaTestContext context)
        {
            _context = context;
        }

        public Mission Mission { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mission = await _context.Missions.FirstOrDefaultAsync(m => m.MissionID == id);

            if (Mission == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
