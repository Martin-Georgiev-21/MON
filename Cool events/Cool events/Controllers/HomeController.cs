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
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }   
        // GET: HomeController
        public ActionResult Index()
        {
            return View("Index");
        }


        public ActionResult Login()
        {
            return View("LogIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(Users obj)
        {
            var activeUser = _db.Users.SingleOrDefault(u => u.Username == obj.Username && u.Password == obj.Password);

            if (activeUser != null)
            {
                Counting.Events = _db.Events.Count();
                Counting.Users = _db.Users.Count();
                Counting.Tickets = _db.Tickets.Count();
                if (activeUser.IsAdmin == true)
                {
                    Logged.IsAdmin = activeUser.IsAdmin;
                    Logged.LoggedIn = true;
                    Logged.LoggedId = activeUser.UserId;
                    return View("../AfterLogInAdmin");
                }
                else
                {
                    Logged.IsAdmin = activeUser.IsAdmin;
                    Logged.LoggedIn = true;
                    Logged.LoggedId = activeUser.UserId;
                    return View("../AfterLogInNoAdmin");
                }
            }
            return View("Login");
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Users obj)
        {
            obj.IsAdmin = false;
            _db.Users.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Login");
        }

        public IActionResult Back()
        {
            var obj = _db.Users.Find(Logged.LoggedId);
            if (obj.IsAdmin == true)
            {
                return View("../AfterLogInAdmin");
            }
            else return View("../AfterLogInNoAdmin");
        }
    }
}
