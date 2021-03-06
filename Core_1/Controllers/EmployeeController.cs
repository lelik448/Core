﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core_1.ViewModels;
using Core_1.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Core_1.Controllers
{
    [Route("users")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Route("idx")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
            //return Content("Hello from home controller");
        }
        [Route("list")]
        [AllowAnonymous]
        public IActionResult EmployeeList()
        {
            return View(_employeeService.GetAll());
        }
        [Route("{id}")]
        [Authorize(Roles = "Admins")]
        public IActionResult Employee(int id)
        {

            var employeeViewModel = _employeeService.GetById(id);

            //Если такого не существует
            if (employeeViewModel == null)
                return NotFound(); // возвращаем результат 404 Not Found

            return View(employeeViewModel);
            //   return View();
            //return Content("Hello from home controller");
        }

        [HttpGet]
        [Authorize(Roles = "Admins")]
        [Route ("edit/{id?}")]
        public IActionResult Edit(int? id)
        {

            if (!id.HasValue)
                return View(new EmployeeViewModel());

            var model = _employeeService.GetById(id.Value);
            if (model == null)
                return NotFound();

            return View(model);

        }
        [HttpPost]
        [Authorize(Roles = "Admins")]
        [Route("edit/{id?}")]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (model.Age < 18 || model.Age > 75)
            {
                ModelState.AddModelError("Age", "Ошибка возраста!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

                if (model.Id > 0)
                {
                    var dbItem = _employeeService.GetById(model.Id);

                    if (ReferenceEquals(dbItem, null))
                        return NotFound();// возвращаем результат 404 Not Found

                    dbItem.FirstName = model.FirstName;
                    dbItem.SurName = model.SurName;
                    dbItem.Age = model.Age;
                    dbItem.Patronymic = model.Patronymic;
                    dbItem.Position = model.Position;
                }
                else
                {
                    _employeeService.AddNew(model);
                }
                _employeeService.Commit();

                return RedirectToAction(nameof(EmployeeList));
        }


        [HttpGet]
        [Authorize(Roles = "Admins")]
        [Route("delete/{id?}")]
        public IActionResult Delete(int? id)
        {

            if (!id.HasValue)
                return NotFound();

            _employeeService.Delete(id.Value);

            return RedirectToAction(nameof(EmployeeList));

        }


    }


}