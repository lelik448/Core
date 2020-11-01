using Core.DAL;
using Core.Domain.Entities;
using Core.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Infrastructure.Services
{
    public class SqlProductService : IProductService
    {
        private CoreContext _context;

        public SqlProductService(CoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            /*var contextProducts = _context.Products.AsQueryable();*/
            var contextProducts = _context
               .Products
               .Include(p => p.Category)
               .Include(p => p.Brand)
               .AsQueryable();
            if (filter.BrandId.HasValue)
                contextProducts.Where(c => c.BrandId.HasValue && c.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.CategoryId.HasValue)
                contextProducts = contextProducts.Where(c => c.CategoryId.Equals(filter.CategoryId.Value));

            return contextProducts.ToList();
        }
        public Product GetProductById(int id)
        {
            if (id == 0)
            {
                return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .FirstOrDefault();
            }
            return _context
                .Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
