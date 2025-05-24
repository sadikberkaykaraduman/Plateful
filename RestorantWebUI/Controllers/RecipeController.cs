using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restorant.WebUI.Dtos.ReceipeDtos;

namespace Restorant.WebUI.Controllers
{
    [AllowAnonymous]
    public class RecipeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=60&tags=under_30_minutes"),
                Headers =
    {
        { "x-rapidapi-key", "580342898cmshec2899f1f3dcdebp176b28jsncde4e6b2df78" },
        { "x-rapidapi-host", "tasty.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<RootReceipeDto>(body);
                var values = root.Results;
                return View(values.ToList());
            }
        }
    }
}
