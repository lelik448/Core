using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core_1.ViewModels;


namespace Core_1.Controllers
{
    public class ClientController : Controller
    {

        private readonly List<ClientViewModel> _clients = new List<ClientViewModel>
        {
            new ClientViewModel
            {
                Id = 1,
                FirstName = "Иван",
                SurName = "Иванов",
                City = "Москва",
                RegistrationDate = new DateTime (2020,10,08),
                Status = "Начальник"
            },
            new ClientViewModel
            {
                Id = 2,
                FirstName = "Владислав",
                SurName = "Петров",
                City = "Санкт-Петербург",
                RegistrationDate = new DateTime (2020,10,07),
                Status = "Начальник"
            }
        };


        public IActionResult Index()
        {
            return View();
            //return Content("Hello from home controller");
        }

        public IActionResult ClientList()
        {
            return View(_clients);
        }
        public IActionResult Client(int id)
        {

            var clientViewModel = _clients.FirstOrDefault(x => x.Id == id);

            //Если такого не существует
            if (clientViewModel == null)
                return NotFound(); // возвращаем результат 404 Not Found

            return View(clientViewModel);
            //   return View();
            //return Content("Hello from home controller");
        }
    }
}