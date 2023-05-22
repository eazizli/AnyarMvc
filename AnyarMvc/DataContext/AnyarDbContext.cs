using AnyarMvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnyarMvc.DataContext
{
    public class AnyarDbContext:IdentityDbContext<AppUser>
    {
        public AnyarDbContext(DbContextOptions<AnyarDbContext> opt):base(opt) 
        {
            
        }
        public DbSet<Team> Teams { get; set; }
      
    }
}
