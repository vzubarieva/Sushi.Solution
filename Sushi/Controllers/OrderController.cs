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
using System;
using System.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Sushi.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly SushiContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        // private readonly ILogger<OrdersController> _logger;

        public OrdersController(
            SushiContext db,
            UserManager<ApplicationUser> userManager
        // ILogger<OrdersController> logger
        )
        {
            _userManager = userManager;
            _db = db;
            // _logger = logger;
        }

        public ActionResult Index()
        {
            List<Order> model = _db.Orders.ToList();
            // then in orders index we can show items ordered (from virtual property OrderItems)

            return View(model);
        }

        public ActionResult Create()
        {
            List<MenuItem> model = _db.MenuItems.ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(IFormCollection items)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);

            // TODO:
            // shape of form collection:
            // {
            //   [itemId]: [countOrdered],
            //   2: 34,
            //   2: 0,
            // }
            //
            // iterate over items
            // do nothing if value is 0, it means 0 of this item were ordered
            // create orderItems from items > 0 (do not forget to set orderId)
            // sum all prices into one variable, assign it to both subTotalPrice and TotalPrice
            // assign ItemsCount with count of all items wit > 0 ordered
            // add all order items to _db

            Order order = new Order
            {
                subTotalPrice = 56,
                TotalPrice = 56,
                ItemsCount = items.Count,
                UserId = currentUser.Id
            };

            _db.Add(order);

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
