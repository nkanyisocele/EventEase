using EventEase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EventEase.Data
{
    public class ApplicationDbContext : DbContext
    {
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
