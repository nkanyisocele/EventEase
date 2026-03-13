using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class VenueDto
    {
        [Required]
        public string VenueName { get; set; } = "";
        [Required]
        public string Location { get; set; } = "";
        [Required]
        public int Capacity { get; set; }
        
        public IFormFile? ImageFile { get; set; }
    }
}
