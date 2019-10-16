using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FGear.Data;

namespace FGear.Pages.myRoles
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
            return Page();
        }

        [BindProperty]
        public Roles Roles { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Roles.Add(Roles);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}