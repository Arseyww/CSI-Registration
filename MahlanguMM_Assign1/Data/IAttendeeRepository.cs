using MahlanguMM_Assign1.Models;

namespace MahlanguMM_Assign1.Data
{
    public interface IAttendeeRepository
    {
        IEnumerable<Attendee> GetAllAttendies();
        IEnumerable<Attendee> GetAllAttendeesWithCapacityDetails();
        IEnumerable<Capacity> GetAllCapasity();
        Attendee GetMovieById(int id);
        void AddAttendee(Attendee attendee);
        void UpdateAttendee(Attendee attendee);
        void DeleteAttendee(Attendee attendee);
        void SaveChanges();
        bool EmailExists(string email);
    }
}
