using MahlanguMM_Assign1.Models;
using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace MahlanguMM_Assign1.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Capacity> Capacities { get; set; }

    }
}
