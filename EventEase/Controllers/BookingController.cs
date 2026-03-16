using EventEase.Data;
using EventEase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            Booking booking = new Booking
            {
                BookingId = bookingDto.BookingId,
                EventId = bookingDto.EventId,
                VenueId = bookingDto.VenueId,
                BookingDate = bookingDto.BookingDate
            };
            context.Bookings.Add(booking);
            context.SaveChanges();


            return RedirectToAction("Index", "Booking");
        }
        public IActionResult Edit(int BookingId)
        {
            var booking = context.Events.Find(BookingId);
            if (booking == null)
            {
                return RedirectToAction("Index", "Booking");
            }
            BookingDto bookingDto = new BookingDto
            {
                BookingId = booking.BookingId,
                EventId = booking.EventId,
                VenueId = booking.VenueId,
                BookingDate = booking.BookingDate
            };

            ViewData["BookingId"] = BookingId;
            ViewData["EventId"] = booking.EventId;
            ViewData["VenueId"] = booking.VenueId;
            ViewData["BookingDate"] = booking.BookingDate.ToString("MM/dd/YYYY");

            return View(bookingDto);

            booking.EventId = bookingDto.EventId;
            booking.VenueId = bookingDto.VenueId;
            booking.BookingDate = bookingDto.BookingDate;

            context.SaveChanges();
            return RedirectToAction("Index", "Booking");
        }
    }   
}
