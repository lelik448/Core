using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Core_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult Blog_single()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult Product_details()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Contact_us()
        {
            return View();
        }
        public IActionResult _404 ()
        {
            return View();
        }


    }
}
