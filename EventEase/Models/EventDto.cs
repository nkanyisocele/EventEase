using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class EventDto
    {
        [Required]
        public int EventId { get; set; }
        [Required]
        public string EventName { get; set; } = "";
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public string Description { get; set; } = "";
        [Required]
        public int VenueId { get; set; }
       
    }
}
