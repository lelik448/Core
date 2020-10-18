using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core_1.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Core_1.Infrastructure.Interfaces;

namespace Core_1.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clients;

        public ClientController(IClientService clients)
        {
            _clients = clients;
        }


        public IActionResult ClientList()
        {
            return View(_clients.GetAll());
        }
        [Route("{id}")]
        public IActionResult Client(int id)
        {

            var clientViewModel = _clients.GetById(id);

            //Если такого не существует
            if (clientViewModel == null)
                return NotFound(); // возвращаем результат 404 Not Found

            return View(clientViewModel);
            //   return View();
            //return Content("Hello from home controller");
        }

        [HttpGet]
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {

            if (!id.HasValue)
                return View(new ClientViewModel());

            var model = _clients.GetById(id.Value);
            if (model == null)
                return NotFound();

            return View(model);

        }
        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(ClientViewModel model)
        {
            if (model.Id > 0)
            {
                var dbItem = _clients.GetById(model.Id);

                if (ReferenceEquals(dbItem, null))
                    return NotFound();// возвращаем результат 404 Not Found

                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.RegistrationDate = model.RegistrationDate;
                dbItem.Status = model.Status;
                dbItem.City = model.City;
            }
            else
            {
                _clients.AddNew(model);
            }
            _clients.Commit();

            return RedirectToAction(nameof(ClientList));
        }


        [HttpGet]
        [Route("delete/{id?}")]
        public IActionResult Delete(int? id)
        {

            if (!id.HasValue)
                return NotFound();

            _clients.Delete(id.Value);

            return RedirectToAction(nameof(ClientList));

        }
    }
}