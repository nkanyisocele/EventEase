using EventEase.Data;
using EventEase.Models;
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
            
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }


    }
}
