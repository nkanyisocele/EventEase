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
            var events = context.Events.ToList();
            return View(events);
        }
    }
}
