using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restorant.WebUI.Dtos.BasketDtos;
using System.Threading.Tasks;

namespace Restorant.WebUI.Controllers
{
    [AllowAnonymous]
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            TempData["id"] = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44301/api/Basket/GetListWithProductByMenuTableId/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var  jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketWithProduct>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            id = int.Parse(TempData["id"].ToString());
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44301/api/Basket/DeleteBasket/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }

    }
}
