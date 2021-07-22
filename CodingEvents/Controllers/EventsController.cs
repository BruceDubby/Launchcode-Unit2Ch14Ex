using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Models;
using CodingEvents.Data;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        
        [HttpGet]
        public IActionResult Index()
        {
            //Events.Add("Strange Loop");
            //Events.Add("Grace Hopper");.0
            //Events.Add("Code with Pride");

            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);
            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int [] eventsIds)
        {
            foreach(int eventId in eventsIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }

        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            // controller code will go here
            Event editEvent = EventData.GetById(eventId);
            ViewBag.edit = editEvent; 
            ViewBag.title = $"Edit Event {editEvent.Name} (id={eventId})";
            
            return View();
        }

        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            // controller code will go here
            Event submitEdit = EventData.GetById(eventId);
            submitEdit.Name = name;
            submitEdit.Description = description;
            return Redirect("/Events");
        }

    }
}
