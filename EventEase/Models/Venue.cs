using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Venue
    {
        [Key]
        [Display(Name = "Venue Id")]
        public int VenueId { get; set; }
        [Required]
        [Display(Name = "Venue Name")]
        public string VenueName { get; set; } = "";
        public string Location { get; set; } = "";
        public int Capacity { get; set; }

        public string ImageFileName { get; set; } = "";
    }
}
