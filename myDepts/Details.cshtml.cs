﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FGear.Data;

namespace FGear.Pages.myDepts
{
    public class DetailsModel : PageModel
    {
        private readonly FGear.Data.ApplicationDbContext _context;

        public DetailsModel(FGear.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
