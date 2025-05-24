using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restorant.WebUI.Dtos.FeatureDtos;

namespace Restorant.WebUI.ViewComponents.ShowCaseViewComponents
{
    public class _ShowCaseSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ShowCaseSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44301/api/Feature/GetAllFeatures");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
