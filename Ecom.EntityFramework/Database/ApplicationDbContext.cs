using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.BFF.Core.Models;

namespace WebApp.BFF.Database
{
    public class EcomContext : IdentityDbContext<ApplicationUser>
    {
        public EcomContext(DbContextOptions<EcomContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}