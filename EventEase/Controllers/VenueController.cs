using EventEase.Data;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Controllers
{
    public class VenueController : Controller
    {
        private readonly ApplicationDbContext context;

        public VenueController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var venues = context.Venues.ToList();
            return View(venues);
        } 
    }
}
