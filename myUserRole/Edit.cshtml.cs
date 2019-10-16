using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FGear.Data;

namespace FGear.Pages.myUserRole
{
    public class EditModel : PageModel
    {
        private readonly FGear.Data.ApplicationDbContext _context;

        public EditModel(FGear.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["RID"] = new SelectList(_context.Roles, "RID", "RID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRolesExists(UserRoles.URID))
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

        private bool UserRolesExists(int id)
        {
            return _context.UserRoles.Any(e => e.URID == id);
        }
    }
}
