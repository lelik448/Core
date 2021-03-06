﻿using Core.Domain.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class CategoryViewModel: INamedEntity,IOrderedEntity
    {
        public CategoryViewModel()
        {
            ChildCategories = new List<CategoryViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        /// <summary>
        /// Дочерние секции
        /// </summary>
        public List<CategoryViewModel> ChildCategories { get; set; }

        /// <summary>
        /// Родительская секция
        /// </summary>
        public CategoryViewModel ParentCategory { get; set; }
    }
}
