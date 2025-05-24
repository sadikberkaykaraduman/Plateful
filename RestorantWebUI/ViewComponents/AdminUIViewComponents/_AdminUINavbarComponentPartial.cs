using Microsoft.AspNetCore.Mvc;

namespace Restorant.WebUI.ViewComponents.AdminUIViewComponents
{
    public class _AdminUINavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
