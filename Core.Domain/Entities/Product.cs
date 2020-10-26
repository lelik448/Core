﻿using Core.Domain.Entities.Base;
using Core.Domain.Entities.Base.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Products")]
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int CategoryId { get; set; }
       
        public int? BrandId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        public DateTime ProductionDate { get; set; }

        public string Manufacturer { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("BrandId")]
       public virtual Brand Brand { get; set; }
}
