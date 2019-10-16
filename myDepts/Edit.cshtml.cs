using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FGear.Data;

namespace FGear.Pages.myDepts
{
    public class EditModel : PageModel
    {
        private readonly FGear.Data.ApplicationDbContext _context;

        public EditModel(FGear.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Depts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptsExists(Depts.DeptID))
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

        private bool DeptsExists(int id)
        {
            return _context.Depts.Any(e => e.DeptID == id);
        }
    }
}
