using MahlanguMM_Assign1.Models;
using Microsoft.EntityFrameworkCore;

namespace MahlanguMM_Assign1.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.CreateScope()
            .ServiceProvider.GetRequiredService<AppDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Capacities.Any())
            {
                context.Capacities.AddRange(
                new Capacity { CapacityName = "Student" },
                new Capacity { CapacityName = "Lecturer" },
                new Capacity { CapacityName = "Researcher" }
                );
            }
            context.SaveChanges();
            if (!context.Attendees.Any())
            {
                context.Attendees.AddRange(
                new Attendee
                {
                    Name = "Sandy",
                    Email = "sandy@gmail.com",
                    PhoneNumber =
               "0821001111",
                    CapacityId = 1
                },
                new Attendee
                {
                    Name = "Mandy",
                    Email = "mandy@gmail.com",
                    PhoneNumber =
               "0821002222",
                    CapacityId = 2
                },
                new Attendee
                {
                    Name = "Hope",
                    Email = "hope@gmail.com",
                    PhoneNumber =
               "0821003333",
                    CapacityId = 3
                },
                new Attendee
                {
                    Name = "Peter",
                    Email = "peter@gmail.com",
                    PhoneNumber =
               "0821004444",
                    CapacityId = 2
                },
                new Attendee
                {
                    Name = "Thabo",
                    Email = "thabo@gmail.com",
                    PhoneNumber =
               "0821005555",
                    CapacityId = 2
                },
                new Attendee
                {
                    Name = "Andy",
                    Email = "andy@gmail.com",
                    PhoneNumber =
               "08210016666",
                    CapacityId = 3
                }
                );
            }
            context.SaveChanges();
        }
    }
}
