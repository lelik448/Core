﻿using Core.Domain.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class BrandViewModel: INamedEntity,IOrderedEntity
    {
      

        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public int BrandsCount { get; set; }

        
        
    }
}
