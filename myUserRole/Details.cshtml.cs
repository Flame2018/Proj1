using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FGear.Data;

namespace FGear.Pages.myUserRole
{
    public class DetailsModel : PageModel
    {
        private readonly FGear.Data.ApplicationDbContext _context;

        public DetailsModel(FGear.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public UserRoles UserRoles { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserRoles = await _context.UserRoles
                .Include(u => u.RoleID).FirstOrDefaultAsync(m => m.URID == id);

            if (UserRoles == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
