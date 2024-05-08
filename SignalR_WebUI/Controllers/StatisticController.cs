using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
