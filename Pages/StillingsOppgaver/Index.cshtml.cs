using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VismaTest.Data;
using VismaTest.Models;

namespace VismaTest.Pages.StillingsOppgaver
{
    public class IndexModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public IndexModel(VismaTest.Data.VismaTestContext context)
        {
            _context = context;
        }

        public IList<StillingsOppgave> StillingsOppgave { get;set; }

        public async Task OnGetAsync()
        {
            StillingsOppgave = await _context.StillingsOppgave
                .Include(s => s.Oppgave)
                .Include(s => s.Stilling).ToListAsync();
        }
    }
}
