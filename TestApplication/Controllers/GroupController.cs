using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestApplication.Data;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class GroupController : Controller
    {
        private readonly ApplicationDBContext _db;
        public GroupController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Group> groupList = _db.Group;
            return View(groupList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Group obj)
        {
            if (ModelState.IsValid)
            {
                _db.Group.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var obj = _db.Group.Find(id);
            if (obj == null) return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Group obj)
        {
            if (ModelState.IsValid)
            {
                _db.Group.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var obj = _db.Group.Find(id);
            if (obj == null) return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Group obj)
        {
            if (obj == null) return NotFound();

            _db.Group.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
