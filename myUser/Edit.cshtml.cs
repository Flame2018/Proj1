using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FGear.Data;

namespace FGear.Pages.myUser
{
    public class EditModel : PageModel
    {
        private readonly FGear.Data.ApplicationDbContext _context;

        public EditModel(FGear.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Users Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Users = await _context.Users
                .Include(u => u.UsersRolesID).FirstOrDefaultAsync(m => m.UID == id);

            if (Users == null)
            {
                return NotFound();
            }
           ViewData["URID"] = new SelectList(_context.Set<UserRoles>(), "URID", "URID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(Users.UID))
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

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UID == id);
        }
    }
}
