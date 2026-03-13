using EventEase.Data;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Controllers
{    
    public class EventController : Controller
    {
        private readonly ApplicationDbContext context;

        public EventController(ApplicationDbContext context)
        {
            this.context = context;
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
    }
}
