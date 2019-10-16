using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FGear.Data;

namespace FGear.Pages.myEmploys
{
    public class IndexModel : PageModel
    {
        private readonly FGear.Data.ApplicationDbContext _context;

        public IndexModel(FGear.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employs> Employs { get;set; }

        public async Task OnGetAsync()
        {
            Employs = await _context.Employs
                .Include(e => e.Departments)
                .Include(e => e.UserRolesId).ToListAsync();
        }
    }
}
