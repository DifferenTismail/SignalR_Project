using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
