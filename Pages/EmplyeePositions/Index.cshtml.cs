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
    public class IndexModel : PageModel
    {
        private readonly VismaTest.Data.VismaTestContext _context;

        public IndexModel(VismaTest.Data.VismaTestContext context)
        {
            _context = context;
        }

        public IList<EmployeePosition> EmployeePosition { get;set; }

        public async Task OnGetAsync()
        {
            EmployeePosition = await _context.EmployeePositions.ToListAsync();
        }
    }
}
