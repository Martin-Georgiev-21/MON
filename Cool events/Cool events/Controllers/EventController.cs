using Cool_events.Data;
using Cool_events.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cool_events.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EventController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: EventController
        public IActionResult Index(string searchString)
        {
            var events = from e in _db.Events
                        select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                events = events.Where(c =>
                    c.Name.Contains(searchString));
            }

            ViewData["CurrentFilter"] = searchString;

            IEnumerable<Users> users = _db.Users;
            IEnumerable<Tickets> tickets = _db.Tickets;
            BigView bigView = new BigView(events, users, tickets);

            return View(bigView);
        }

        public IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEvent(Events obj)
        {
            _db.Events.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditEvent(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Events.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            Logged.CurrentEvent = obj;
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEvent(Events obj)
        {
            _db.Events.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEvent(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Events.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return DeleteEvent(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEvent(Events obj)
        {
            _db.Events.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetTicket(int id)
        {
            Tickets ticket = new Tickets();
            ticket.Event = id;
            ticket.User = Logged.LoggedId;
            _db.Tickets.Add(ticket);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
