using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Product.Data.Context;

namespace Product.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDataContext _context;
        public ProductRepository(ProductDataContext context)
        {
            _context = context;
        }

        public Entities.Product GetById(Int32 id)
        {
            return _context
                .Products
                .Include(x => x.ProductMaterials)
                .Include(x => x.ProductMaterials.Select(y => y.Material))
                .FirstOrDefault(x => x.ProductId == id);
        }

        public IList<Entities.Product> GetAll()
        {
            return _context
                   .Products
                   .Include(x => x.ProductMaterials)
                   .Include(x => x.ProductMaterials.Select(y => y.Material))
                   .ToList();
        }

        public void Update(Int32 id, String name, Decimal price)
        {
            var entity = _context.Products.First(x => x.ProductId == id);
            entity.Name = name;
            entity.Price = price;
        }

        public void Delete(Int32 id)
        {
            var entity = _context.Products.First(x => x.ProductId == id);
            _context.Products.Remove(entity);
        }


        

    }
}