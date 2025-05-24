using Microsoft.AspNetCore.Mvc;

namespace Restorant.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
