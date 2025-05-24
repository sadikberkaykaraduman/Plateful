using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restorant.WebUI.Dtos.BookingDtos;

namespace Restorant.WebUI.ViewComponents.ShowCaseViewComponents
{
    public class _ShowCaseMessageComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ShowCaseMessageComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
