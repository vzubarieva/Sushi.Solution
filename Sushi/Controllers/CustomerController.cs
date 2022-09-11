using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Sushi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sushi.Controllers
{
    public class CustomersController : Controller
    {
        private readonly SushiContext _db;

        public CustomersController(SushiContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Customer> model = _db.Customers.Include(customer => customer.MenuItems).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Customer thisCustomer = _db.Customers.FirstOrDefault(
                customer => customer.CustomerId == id
            );
            return View(thisCustomer);
        }

        public ActionResult Edit(int id)
        {
            var thisCustomer = _db.Customers.FirstOrDefault(customer => customer.CustomerId == id);
            return View(thisCustomer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            _db.Entry(customer).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisCustomer = _db.Customers.FirstOrDefault(customer => customer.CustomerId == id);
            return View(thisCustomer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisCustomer = _db.Customers.FirstOrDefault(customer => customer.CustomerId == id);
            _db.Customers.Remove(thisCustomer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
