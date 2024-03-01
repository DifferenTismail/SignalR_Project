using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ProductDto;
using System.Net.Http;
using System.Text;
using CreateProductDto = SignalR_WebUI.Dtos.ProductDtos.CreateProductDto;
using UpdateProductDto = SignalR_WebUI.Dtos.ProductDtos.UpdateProductDto;

namespace SignalR_WebUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMesaj = await client.GetAsync("https://localhost:7178/api/Product/ProductListWithCategory");
			var values = new List<ResultProductWithCategory>();
			if (responseMesaj.IsSuccessStatusCode)
			{
				var jsonData = await responseMesaj.Content.ReadAsStringAsync();
			    values = JsonConvert.DeserializeObject<List<ResultProductWithCategory>>(jsonData);
				return View(values);
			}
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateProduct()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			createProductDto.ProductStatus = true;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMesaj = await client.PostAsync("https://localhost:7178/api/Product", stringContent);
			if (responseMesaj.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7178/api/Product/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> UpdateProduct(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7178/api/Product/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			updateProductDto.ProductStatus = true;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7178/api/Product/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}

	
}
