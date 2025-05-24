using Microsoft.AspNetCore.Mvc;

namespace Restorant.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
