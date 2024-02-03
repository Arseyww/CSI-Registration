using MahlanguMM_Assign1.Models;
using Microsoft.EntityFrameworkCore;

namespace MahlanguMM_Assign1.Data
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly AppDbContext _appDbContext;
        public ConferenceRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }
        public void AddAttendee(Attendee attendee)
        {
            _appDbContext.Attendees.Add(attendee);
        }
        public IEnumerable<Attendee> GetAllAttendeesWithCapacityDetails()
        {
            return _appDbContext.Attendees
            .Include(a => a.Capacity);
        }
        public Attendee GetAttendeeByEmail(string email)
        {
            return _appDbContext.Attendees
            .FirstOrDefault(a => a.Email.ToLower() == email.ToLower());

        }
        public IEnumerable<Capacity> GetCapacities()
        {
            return _appDbContext.Capacities;
        }
        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
