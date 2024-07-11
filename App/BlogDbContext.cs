using App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App
{
    public class BlogDbContext : IdentityDbContext<AppUser, UserRole, int>  
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
           
        }


        public DbSet<Address> Addresses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Address>()
                .HasOne(u => u.User)
                .WithOne();


        }

    }
}
