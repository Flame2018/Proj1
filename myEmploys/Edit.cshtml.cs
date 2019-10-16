using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FGear.Data;

namespace FGear.Pages.myEmploys
{
    public class EditModel : PageModel
    {
        private readonly FGear.Data.ApplicationDbContext _context;

        public EditModel(FGear.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employs Employs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employs = await _context.Employs
                .Include(e => e.Departments)
                .Include(e => e.UserRolesId).FirstOrDefaultAsync(m => m.EID == id);

            if (Employs == null)
            {
                return NotFound();
            }
           ViewData["DID"] = new SelectList(_context.Depts, "DeptID", "DeptID");
           ViewData["URID"] = new SelectList(_context.Set<UserRoles>(), "URID", "URID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Employs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploysExists(Employs.EID))
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

        private bool EmploysExists(int id)
        {
            return _context.Employs.Any(e => e.EID == id);
        }
    }
}
