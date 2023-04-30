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
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TicketController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult IndexAdmin()
        {
            IEnumerable<Events> events = _db.Events;
            IEnumerable<Users> users = _db.Users;
            IEnumerable<Tickets> tickets = _db.Tickets;
            BigView bigView = new BigView(events, users, tickets);

            return View(bigView);
        }
        public ActionResult IndexNoAdmin()
        {
            IEnumerable<Events> events = _db.Events;
            IEnumerable<Users> users = _db.Users;
            IEnumerable<Tickets> tickets = _db.Tickets;
            BigView bigView = new BigView(events, users, tickets);

            return View(bigView);
        }
        public IActionResult AddTicket()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTicket(Tickets obj)
        {
            _db.Tickets.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("IndexAdmin");
        }
        public IActionResult EditTicket(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Tickets.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTicket(Tickets obj)
        {
            _db.Tickets.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("IndexAdmin");
        }
        public IActionResult RemoveTicket(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Tickets.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return RemoveTicket(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveTicket(Tickets obj)
        {
            _db.Tickets.Remove(obj);
            _db.SaveChanges();
            if (Logged.IsAdmin == true)
            {
                return RedirectToAction("IndexAdmin");
            }
            else 
            {
                return RedirectToAction("IndexNoAdmin");
            }
        }
    }
}
