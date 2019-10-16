using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FGear.Data;

namespace FGear.Pages.myEmploys
{
    public class CreateModel : PageModel
    {
        private readonly FGear.Data.ApplicationDbContext _context;

        public CreateModel(FGear.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DID"] = new SelectList(_context.Depts, "DeptID", "DeptID");
        ViewData["URID"] = new SelectList(_context.Set<UserRoles>(), "URID", "URID");
            return Page();
        }

        [BindProperty]
        public Employs Employs { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employs.Add(Employs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}