using EventEase.Data;
using EventEase.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EventEase.Controllers
{
    public class VenueController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public VenueController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Create()
        {
            var venues = context.Venues.OrderByDescending(p => p.VenueId).ToList();
            return View(venues);
        }
        [HttpPost]
        public IActionResult Create(VenueDto venueDto)
        {
            if (venueDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "The image file is redquired");
            }
            if (!ModelState.IsValid)
            {
                return View(venueDto);
            }
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(venueDto.ImageFile!.FileName);

            string imageFullPath = environment.WebRootPath + "/venues/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                venueDto.ImageFile.CopyTo(stream);
            }

            Venue venue = new Venue
            {
                VenueId = venueDto.VenueId,
                VenueName = venueDto.VenueName,
                Location = venueDto.Location,
                Capacity = venueDto.Capacity,
                ImageFileName = "/venues/" + newFileName
            };
            context.Venues.Add(venue);
            context.SaveChanges();

            return RedirectToAction("Index", "Venue");
        }

        public IActionResult Edit(int VenueId)
        {
             var venue = context.Venues.Find(VenueId);
            if (venue == null)
            {
                return RedirectToAction("Index", "Venue");
            }
            VenueDto venueDto = new VenueDto
            {
                VenueId = venue.VenueId,
                VenueName = venue.VenueName,
                Location = venue.Location,
                Capacity = venue.Capacity,
                
            };
            return View(venueDto);
        }
    }
}
