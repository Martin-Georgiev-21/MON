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
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: UserController
        public ActionResult Index()
        {
            IEnumerable<Users> objList = _db.Users;
            return View(objList);
        }

        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(Users obj)
        {
            _db.Users.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditUser(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUser(Users obj)
        {
            _db.Users.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteUser(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return DeleteUser(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(Users obj)
        {
            _db.Users.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

