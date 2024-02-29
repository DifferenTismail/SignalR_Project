using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DtoLayer.CategoryDto;
using SignalR_WebUI.Dtos.CategoryDtos;

namespace SignalR_WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesaj = await client.GetAsync("https://localhost:7178/api/Category");
            if (responseMesaj.IsSuccessStatusCode)
            {
                var jsonData = await responseMesaj.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
