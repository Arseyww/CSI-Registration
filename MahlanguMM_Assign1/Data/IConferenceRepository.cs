using MahlanguMM_Assign1.Models;

namespace MahlanguMM_Assign1.Data
{
    public interface IConferenceRepository
    {
        IEnumerable<Attendee> GetAllAttendeesWithCapacityDetails();
        Attendee GetAttendeeByEmail(string email);
        IEnumerable<Capacity> GetCapacities();
        void AddAttendee(Attendee attendee);
        void SaveChanges();

    }
}
