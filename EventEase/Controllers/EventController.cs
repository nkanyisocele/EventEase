using EventEase.Data;
using EventEase.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
            context.Events.Add(newEvent);
            context.SaveChanges();


            return RedirectToAction("Index", "Event");
        }
        public IActionResult Edit(int EventId)
        {
            var eventt = context.Events.Find(EventId);
            if (eventt == null)
            {
                return RedirectToAction("Index", "Event");
            }
            
            EventDto eventDto = new EventDto
            {
                EventId = eventt.EventId,
                EventName = eventt.EventName,
                EventDate = eventt.EventDate,
                Description = eventt.Description,
                VenueId = eventt.VenueId
            };
            
            ViewData["EventId"] = EventId;
            ViewData["EventName"] = eventt.EventName;
            ViewData["EventDate"] = eventt.EventDate.ToString("MM/dd/YYYY");
            ViewData["Description"] = eventt.Description;
            ViewData["VenueId"] = eventt.VenueId;

            return View(eventDto);

                
            eventt.EventName = eventDto.EventName;
            eventt.EventDate = eventDto.EventDate;
            eventt.Description = eventDto.Description;
            eventt.VenueId = eventDto.VenueId;

           

            context.SaveChanges();
            return RedirectToAction("Index", "Event");

        }
    }
}
