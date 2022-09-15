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
    public class OrdersController : Controller
    {
        private readonly SushiContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(SushiContext db, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult Index()
        {
            List<Order> model = _db.Orders.ToList();
            return View(model);
        }
    }
}
