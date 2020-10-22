using Core.Domain.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Entities.Base
{
    public class BaseEntity : IBaseEntity

    {
        public int Id { get; set; }

    }
}
