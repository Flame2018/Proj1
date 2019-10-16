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
    public class DeleteModel : PageModel
    {
        private readonly FGear.Data.ApplicationDbContext _context;

        public DeleteModel(FGear.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employs = await _context.Employs.FindAsync(id);

            if (Employs != null)
            {
                _context.Employs.Remove(Employs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
