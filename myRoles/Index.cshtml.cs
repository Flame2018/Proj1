using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FGear.Data;

namespace FGear.Pages.myRoles
{
    public class IndexModel : PageModel
    {
        private readonly FGear.Data.ApplicationDbContext _context;

        public IndexModel(FGear.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Roles> Roles { get;set; }

        public async Task OnGetAsync()
        {
            Roles = await _context.Roles.ToListAsync();
        }
    }
}
