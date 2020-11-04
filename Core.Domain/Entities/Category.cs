using Core.Domain.Entities;
using Core.Domain.Entities.Base;
using Core.Domain.Entities.Base.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Categories")]
public class Category : NamedEntity, IOrderedEntity
{
    /// <summary>
    /// Родительская секция (при наличии)
    /// </summary>
    
    public int? ParentId { get; set; }

    public int Order { get; set; }

    [ForeignKey("ParentId")]
    public virtual Category ParentCategory { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}