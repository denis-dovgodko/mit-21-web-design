using lab15_17.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lab15_17.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Session)
                .WithMany(f => f.Tickets)
                .HasForeignKey(t => t.SessionId);
            modelBuilder.Entity<Session>()
                .HasOne(s => s.Film)
                .WithMany(c => c.Sessions)
                .HasForeignKey(s => s.FilmId);
            modelBuilder.Entity<Session>()
                .HasOne(s => s.Hall)
                .WithMany(seat => seat.Sessions)
                .HasForeignKey(s => s.HallId);
        }
    }
}