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
using System.Text;

namespace Sushi.Controllers
{
    public class MenuItemsController : Controller
    {
        private readonly SushiContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public MenuItemsController(SushiContext db, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult Index()
        {
            List<MenuItem> model = _db.MenuItems.ToList();
            return View(model);
        }

        // [HttpPost, ActionName("Index")]
        // public ActionResult SaveIsChecked(MenuItem menuItem)
        // {
        //     _db.Entry(menuItem).State = EntityState.Modified;
        //     _db.SaveChanges();
        //     return RedirectToAction("Index");
        // }

        // [HttpPost]
        // public string Index(IEnumerable[MenuItem] menuItems)
        // {
        //     if (menuItems.Count(x => x.IsChecked) == 0)
        //     {
        //         return "You have not selected any items";
        //     }
        //     else
        //     {
        //         StringBuilder sb = new StringBuilder();
        //         sb.Append("You selected - ");
        //         foreach (MenuItem menuItem in menuItems)
        //         {
        //             if (menuItem.IsChecked)
        //             {
        //                 sb.Append(menuItem.MenuItemName + ", ");
        //             }
        //         }
        //         sb.Remove(sb.ToString().LastIndexOf(","), 1);
        //         return sb.ToString();
        //     }
        // }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(MenuItem menuItem)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            // ViewBag.isLoggedIn = !String.IsNullOrEmpty(currentUser?.Id);
            menuItem.User = currentUser;
            _db.MenuItems.Add(menuItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var thisMenuItem = _db.MenuItems.FirstOrDefault(menuItem => menuItem.MenuItemId == id);
            return View(thisMenuItem);
        }

        public ActionResult Edit(int id)
        {
            var thisMenuItem = _db.MenuItems.FirstOrDefault(menuItem => menuItem.MenuItemId == id);
            return View(thisMenuItem);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Edit(MenuItem menuItem)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            menuItem.User = currentUser;
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

        public ActionResult Menu()
        {
            return View();
        }
    }
}
