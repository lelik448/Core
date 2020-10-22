using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Entities.Base.Interfaces
{
    public interface INamedEntity : IBaseEntity

    {
        string Name { get; set; }
    }
}
