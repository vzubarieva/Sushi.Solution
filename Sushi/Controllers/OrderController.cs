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
using Microsoft.Extensions.Primitives;

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

            // this is how form data looks like:
            // {
            //   [itemId]: [countOrdered],
            //   2: 3,
            //   4: 0,
            //   5: 1,
            // }

            // create total variables
            double subTotalPrice = 0;
            double TotalPrice = 0;
            int ItemsCount = 0;

            Order order = new Order { UserId = currentUser.Id };

            // iterate over items
            foreach (string menuItemId in items.Keys)
            {
                // conversion
                StringValues menuItemCount = "";
                items.TryGetValue(menuItemId, out menuItemCount); // value in formCollection
                int menuItemCountInt = 0;
                int.TryParse(menuItemCount, out menuItemCountInt); // same value but parsed into integer

                // convert to int
                int menuItemIdInt = 0;
                int.TryParse(menuItemId, out menuItemIdInt);

                // do nothing if value is 0, it means 0 of this item were ordered
                if (menuItemCountInt > 0)
                {
                    ItemsCount++;

                    // get menu item
                    MenuItem menuItem = _db.MenuItems.FirstOrDefault(
                        menuItem => menuItem.MenuItemId == menuItemIdInt
                    );

                    // create orderItems (do not forget to set orderId)
                    OrderItem orderItem = new OrderItem
                    {
                        MenuItemPrice = menuItem.MenuItemPrice,
                        MenuItemName = menuItem.MenuItemName,
                        Count = menuItemCountInt,
                        MenuItem = menuItem,
                        Order = order,
                    };

                    // sum all prices into one variable, then assign it to both subTotalPrice and TotalPrice
                    subTotalPrice += menuItem.MenuItemPrice * menuItemCountInt;

                    // add all order items to _db
                    _db.Add(orderItem);
                }
            }

            // assign total values
            order.subTotalPrice = subTotalPrice;
            order.TotalPrice = subTotalPrice * 1.1;
            order.ItemsCount = ItemsCount; // assign ItemsCount with count of all items wit > 0 ordered

            _db.Add(order);

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
