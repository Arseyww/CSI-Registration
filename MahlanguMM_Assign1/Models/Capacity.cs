using System.ComponentModel.DataAnnotations;

namespace MahlanguMM_Assign1.Models
{
    public class Capacity
    {
        public int CapacityId { get; set; }
        public string CapacityName { get; set; }
        // Navigation property
        public List<Attendee> Attendees { get; set; }
    }
}
