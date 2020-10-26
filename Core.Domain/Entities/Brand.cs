using Core.Domain.Entities.Base;
using Core.Domain.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Brands")]
public class Brand : NamedEntity, IOrderedEntity
{
    
    public int Order { get; set; }
    public int Country { get; set; }
}
