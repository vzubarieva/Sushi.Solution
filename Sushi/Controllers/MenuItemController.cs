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

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(MenuItem menuItem)
    {
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

    // [HttpPost]
    // public async Task<ActionResult> Edit(MenuItem menuItem)
    // {
  //     _db.Entry(menuItem).State = EntityState.Modified;
  //     _db.SaveChanges();
  //     return RedirectToAction("Index");
    // }

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

    public ActionResult AboutUs()
    {
        return View();
    }

  }
}
