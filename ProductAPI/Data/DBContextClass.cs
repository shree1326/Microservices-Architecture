using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Data
{
    public class DBContextClass : IdentityDbContext<IdentityUser> //DbContext
    {
        protected readonly IConfiguration Configuration;

        public DBContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Product> Products { get; set; }
    }
}
