using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.ComponentModel.DataAnnotations;


namespace EventEase.Models
{
    public class Event
    {
        [Key]
        [Display(Name = "Event Id")]
        public int EventId { get; set; }
        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; } = "";
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }
        public string Description { get; set; } = "";
        public int VenueId{ get; set; }
        public int BookingId { get; internal set; }
        public DateTime BookingDate { get; internal set; }
    }
}
