using Microsoft.AspNetCore.Mvc;

namespace Restorant.WebUI.ViewComponents.AdminUIViewComponents
{
    public class _AdminUIHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
