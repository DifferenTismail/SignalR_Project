using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
