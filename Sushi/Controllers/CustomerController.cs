using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Sushi.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Sushi.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly SushiContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomersController(UserManager<ApplicationUser> userManager, SushiContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var userCustomers = _db.Customers
                .Where(entry => entry.User.Id == currentUser.Id)
                .ToList();
            // List<Customer> model = _db.Customers.Include(customer => customer.MenuItems).ToList();
            // return View(model);
            return View(userCustomers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            customer.User = currentUser;
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
