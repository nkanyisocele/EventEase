using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Booking
    {
        [Key]
        [Display(Name = "Booking Id")]
        public int BookingId { get; set; }
        [Required]
        [Display(Name = "Event Id")]
        public int EventId { get; set; }
        [Display(Name = "Venue Id")]
        public int VenueId { get; set; }
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }
        


    }
}
