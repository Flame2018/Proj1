using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FGear.Data;

namespace FGear.Pages.myDepts
{
    public class DeleteModel : PageModel
    {
        private readonly FGear.Data.ApplicationDbContext _context;

        public DeleteModel(FGear.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Depts Depts { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Depts = await _context.Depts.FirstOrDefaultAsync(m => m.DeptID == id);

            if (Depts == null)
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

            Depts = await _context.Depts.FindAsync(id);

            if (Depts != null)
            {
                _context.Depts.Remove(Depts);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
