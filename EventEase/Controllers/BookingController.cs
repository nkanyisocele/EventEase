using EventEase.Data;
using EventEase.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public BookingController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var bookings = context.Bookings.OrderByDescending(p => p.BookingId).ToList();
            return View(bookings);
        }
        public IActionResult Create()
        {
            
                return View();
            
        }
        public IActionResult Create(BookingDto bookingDto)
        {
            Booking newBooking = new Booking
            {
                BookingId = bookingDto.BookingId,
                EventId = bookingDto.EventId,
                VenueId = bookingDto.VenueId,
                BookingDate = bookingDto.BookingDate
            };



            return RedirectToAction("Index", "Event");
        }
    }   
}
