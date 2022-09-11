using Microsoft.AspNetCore.Mvc;

namespace Sushi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }


    }
}
