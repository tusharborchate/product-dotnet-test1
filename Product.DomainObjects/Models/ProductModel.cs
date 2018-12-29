using System;
using System.Collections.Generic;

namespace Product.DomainObjects.Models
{
    public class ProductModel
    {
        public Int32 ProductId { get; set; }

        public String Name { get; set; }

        public Decimal Price { get; set; }

        public IList<ProductMaterialModel> Materials { get; set; }
    }
}