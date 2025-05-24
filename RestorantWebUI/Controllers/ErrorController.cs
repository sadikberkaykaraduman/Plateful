using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Restorant.WebUI.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public IActionResult NotFound404Page()
        {
            return View();
        }
    }
}
