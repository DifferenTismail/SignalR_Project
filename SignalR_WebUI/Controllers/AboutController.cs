using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DtoLayer.AboutDto;
using System.Text;

namespace SignalR_WebUI.Controllers
{
	public class AboutController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AboutController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMesaj = await client.GetAsync("https://localhost:7178/api/About");
			if (responseMesaj.IsSuccessStatusCode)
			{
				var jsonData = await responseMesaj.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateAbout()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createAboutDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMesaj = await client.PostAsync("https://localhost:7178/api/About", stringContent);
			if (responseMesaj.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteAbout(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7178/api/About/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
			public async Task<IActionResult> UpdateAbout(int id)
			{
				var client = _httpClientFactory.CreateClient();
				var responseMessage = await client.GetAsync($"https://localhost:7178/api/About/{id}");
				if (responseMessage.IsSuccessStatusCode)
				{
					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
					return View(values);
				}
				return View();

			}
		[HttpPost]
		public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateAboutDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7178/api/About/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
