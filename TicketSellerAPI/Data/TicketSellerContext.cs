using Microsoft.EntityFrameworkCore;
using TicketSellerAPI.Models;

namespace TicketSellerAPI.Data
{
    public class TicketSellerContext : DbContext
    {
        public TicketSellerContext(DbContextOptions<TicketSellerContext> options)
            : base(options)
        {
        }

        public DbSet<Occasion> Occasions { get; set; }
        public DbSet<OccasionCategory> OccasionCategories { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OccasionCategory>().ToTable("occasionCategory");
            modelBuilder.Entity<User>().ToTable("Users");
            
        }
    }
}