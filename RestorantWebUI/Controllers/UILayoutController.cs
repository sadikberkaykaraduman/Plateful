using Microsoft.AspNetCore.Mvc;

namespace Restorant.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
