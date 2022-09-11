using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Sushi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sushi.Controllers
{
    public class MenuItemsController : Controller
    {
        private readonly SushiContext _db;

        public MenuItemsController(SushiContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<MenuItem> model = _db.MenuItems.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "CustomerName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(MenuItem menuItem)
        {
            _db.MenuItems.Add(menuItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisMenuItem = _db.MenuItems.FirstOrDefault(menuItem => menuItem.MenuItemId == id);
            return View(thisMenuItem);
        }

        public ActionResult Edit(int id)
        {
            var thisMenuItem = _db.MenuItems.FirstOrDefault(menuItem => menuItem.MenuItemId == id);
            ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "CustomerName");
            return View(thisMenuItem);
        }

        [HttpPost]
        public ActionResult Edit(MenuItem menuItem)
        {
            _db.Entry(menuItem).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisMenuItem = _db.MenuItems.FirstOrDefault(menuItem => menuItem.MenuItemId == id);
            return View(thisMenuItem);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisMenuItem = _db.MenuItems.FirstOrDefault(menuItem => menuItem.MenuItemId == id);
            _db.MenuItems.Remove(thisMenuItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
