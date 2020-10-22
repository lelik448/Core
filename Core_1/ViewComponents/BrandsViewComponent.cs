using Core.Infrastructure.Interfaces;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ViewComponents
{
    public class BrandsViewComponent:ViewComponent
    {
        private readonly IProductService _productService;

        public BrandsViewComponent(IProductService productService)
        {
            this._productService = productService;
        }

        private IEnumerable<BrandViewModel> GetBrands ()
        {
            var Brands = _productService.GetBrands();


            return Brands.Select(b => new BrandViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Order = b.Order,
                BrandsCount = 0
            }).OrderBy(b => b.Order).ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Brands = GetBrands();
            return View(Brands);
        }

    }
}
