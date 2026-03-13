using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class BookingDto
    {
        [Required]
        public int BookingId { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int VenueId { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
    }
}
