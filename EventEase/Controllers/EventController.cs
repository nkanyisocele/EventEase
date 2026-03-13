using EventEase.Data;
using EventEase.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Controllers
{    
    public class EventController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public EventController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var events = context.Events.OrderByDescending(p => p.EventId).ToList();
            return View(events);
        }
        public IActionResult Create()
        {
            
                return View();
            
        }
        public IActionResult Create(EventDto eventDto)
        {
            Event newEvent = new Event
            {
                EventName = eventDto.EventName,
                EventDate = eventDto.EventDate,
                Description = eventDto.Description,
                VenueId = eventDto.VenueId
            };  



            return RedirectToAction("Index", "Event");
        }
    }
}
