using hrsystem.data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrsystem.Context
{
    public class HRContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> employees { set; get; }
        public DbSet<Department> departments { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=localhost;Initial catalog=hrsystem;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
