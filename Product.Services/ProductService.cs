using System;
using System.Collections.Generic;
using System.Linq;
using Product.Data.Repositories;
using Product.DomainObjects.Models;

namespace Product.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductModel GetById(Int32 id)
        {
            return Transfer(_productRepository.GetById(id));
        }

        public IList<ProductModel> GetAll()
        {
            return _productRepository.GetAll().Select(Transfer).ToList();
        }

        private ProductModel Transfer(Data.Entities.Product entity)
        {
            var p = new ProductModel
            {
                ProductId = entity.ProductId,
                Name = entity.Name,
                Price = entity.Price,
                Materials = new List<ProductMaterialModel>()
            };


            foreach(var m in entity.ProductMaterials)
            {
                var material = new ProductMaterialModel {Quantity = m.Quantity};
                material.MaterialName = m.Material.Name;
                material.Quantity = m.Quantity;
                material.MaterialId = m.MaterialId;

                p.Materials.Add(material);
            }

            return p;
        }


    }
}