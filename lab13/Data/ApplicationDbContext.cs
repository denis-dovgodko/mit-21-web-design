using lab13.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lab13.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}