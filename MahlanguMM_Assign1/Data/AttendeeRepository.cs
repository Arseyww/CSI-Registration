using MahlanguMM_Assign1.Models;
using Microsoft.EntityFrameworkCore;

namespace MahlanguMM_Assign1.Data
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly AppDbContext appDbContext;

        public AttendeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Attendee> GetAllAttendies()
        {
              return appDbContext.Attendees;
           
        }

        public void AddAttendee(Attendee attendee)
        {
            appDbContext.Attendees.Add(attendee);
        }

        public void DeleteAttendee(Attendee attendee)
        {
           appDbContext.Attendees.Remove(attendee);
        }

        public IEnumerable<Capacity> GetAllCapasity()
        {
            return appDbContext.Capacities;
        }

        public Attendee GetMovieById(int id)
        {
            return appDbContext.Attendees.FirstOrDefault(m => m.AttendeeId == id);
        }

        public void SaveChanges()
        {
           appDbContext.SaveChanges();
        }

        public void UpdateAttendee(Attendee attendee)
        {
            appDbContext.Attendees.Update(attendee);
        }

        public IEnumerable<Attendee> GetAllAttendeesWithCapacityDetails()
        {
            return appDbContext.Attendees.Include(a => a.Capacity);
        }
        public bool EmailExists(string email)
        {
            return appDbContext.Attendees.Any(a => a.Email == email);
        }
    }
}
