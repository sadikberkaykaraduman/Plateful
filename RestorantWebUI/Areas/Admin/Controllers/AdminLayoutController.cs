using Microsoft.AspNetCore.Mvc;

namespace Restorant.WebUI.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
