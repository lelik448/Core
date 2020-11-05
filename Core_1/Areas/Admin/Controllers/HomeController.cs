using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Core.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Areas.Admin.Controllers
{
   
        [Area("Admin")]
        [Authorize(Roles = "Admins")]
        public class HomeController : Controller
        {
            private readonly IProductService _productService;

            public HomeController(IProductService productService)
            {
                _productService = productService;
            }

            public IActionResult Index()
            {
                return View(_productService.GetProducts(new ProductFilter()));
            }
        }
    }
