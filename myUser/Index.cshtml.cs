using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FGear.Data;

namespace FGear.Pages.myUser
{
    public class IndexModel : PageModel
    {
        private readonly FGear.Data.ApplicationDbContext _context;

        public IndexModel(FGear.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users
                .Include(u => u.UsersRolesID).ToListAsync();
        }
    }
}
