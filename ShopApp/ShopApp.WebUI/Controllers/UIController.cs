using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShopApp.WebUI.Controllers
{
    public class UIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public  IActionResult ContactUs()
        {
            return View();
        }
        public  IActionResult AboutUs()
        {
            return View();
        }
    }
}
