using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_1.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }

    }
}
