using System;
using System.Collections.Generic;
using Product.DomainObjects.Models;

namespace Product.Services
{
    public interface IProductService
    {
        ProductModel GetById(Int32 id);
        IList<ProductModel> GetAll();
    }
}