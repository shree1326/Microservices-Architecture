using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserAPI.Models;
//using UserAPI.Auth;

namespace UserAPI.Data
{
    public class DbContextClass : IdentityDbContext<IdentityUser> //DbContext
    {
        protected readonly IConfiguration Configuration;
        //public DbContextClass() { }

        //public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        //{
        //}
      
        public DbContextClass(IConfiguration configuration)
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

        public DbSet<User> Users { get; set; }
    }
}