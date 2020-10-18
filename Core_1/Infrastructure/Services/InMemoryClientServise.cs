using Core_1.Infrastructure.Interfaces;
using Core_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_1.Infrastructure
{
    public class InMemoryClientServise : IClientService
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

        public void AddNew(ClientViewModel model)
        {
            if (_clients.Count>0)
                model.Id = _clients.Max(e => e.Id) + 1;
            else
                model.Id =1;
           _clients.Add(model);

        }

        public void Commit()
        {
            //throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var client = GetById(id);
            if (client != null)
            {
                _clients.Remove(client);
            }

        }

        public IEnumerable<ClientViewModel> GetAll()
        {
            return _clients;
            
        }

        public ClientViewModel GetById(int id)
        {
            return _clients.FirstOrDefault(e => e.Id.Equals(id));
         
        }

       

    }
}
