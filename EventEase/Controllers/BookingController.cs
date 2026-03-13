using EventEase.Data;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext context;

        public BookingController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var bookings = context.Bookings.ToList();
            return View(bookings);
        }
    }
}
