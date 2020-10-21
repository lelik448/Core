using Core.Domain.Entities.Base;
using Core.Domain.Entities.Base.Interfaces;

public class Brand : NamedEntity, IOrderedEntity
{
    public int Order { get; set; }
}
