using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core_1.ViewModels;


namespace Core_1.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly List<EmployeeViewModel> _employees = new List<EmployeeViewModel>
        {
            new EmployeeViewModel
            {
                Id = 1,
                FirstName = "Иван",
                SurName = "Иванов",
                Patronymic = "Иванович",
                Age = 22,
                Position = "Начальник"
            },
            new EmployeeViewModel
            {
                Id = 2,
                FirstName = "Владислав",
                SurName = "Петров",
                Patronymic = "Иванович",
                Age = 35,
                Position = "Программист"
            }
        };


        public IActionResult Index()
        {
            return View();
            //return Content("Hello from home controller");
        }

        public IActionResult EmployeeList()
        {
            return View(_employees);
        }
        public IActionResult Employee(int id)
        {

            var employeeViewModel = _employees.FirstOrDefault(x => x.Id == id);

            //Если такого не существует
            if (employeeViewModel == null)
                return NotFound(); // возвращаем результат 404 Not Found

            return View(employeeViewModel);
            //   return View();
            //return Content("Hello from home controller");
        }
    }
}