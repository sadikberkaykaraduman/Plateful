using Microsoft.AspNetCore.Mvc;

namespace Restorant.WebUI.ViewComponents.AdminUIViewComponents
{
    public class _AdminUISidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
