using Microsoft.AspNetCore.Mvc;

namespace Restorant.WebUI.ViewComponents.AdminUIViewComponents
{
    public class _AdminUIScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
