using Microsoft.AspNetCore.Mvc;

namespace Restorant.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
