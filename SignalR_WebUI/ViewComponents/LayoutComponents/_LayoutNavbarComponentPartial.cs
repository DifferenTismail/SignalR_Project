﻿using Microsoft.AspNetCore.Mvc;
namespace SignalR_WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
