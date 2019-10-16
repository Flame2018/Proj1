using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FGear.Data;

namespace FGear.Pages.myUserRole
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
        ViewData["RID"] = new SelectList(_context.Roles, "RID", "RID");
            return Page();
        }

        [BindProperty]
        public UserRoles UserRoles { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserRoles.Add(UserRoles);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}