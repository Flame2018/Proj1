using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FGear.Data;

namespace FGear.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FGear.Data.Depts> Depts { get; set; }
        public DbSet<FGear.Data.Employs> Employs { get; set; }
        public DbSet<FGear.Data.Roles> Roles { get; set; }
        public DbSet<FGear.Data.Users> Users { get; set; }
        public DbSet<FGear.Data.UserRoles> UserRoles { get; set; }
    }
}
