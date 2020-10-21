using Core.Domain.Entities.Base;
using Core.Domain.Entities.Base.Interfaces;

public class Category : NamedEntity, IOrderedEntity
{
    /// <summary>
    /// Родительская секция (при наличии)
    /// </summary>
    public int? ParentId { get; set; }

    public int Order { get; set; }
}