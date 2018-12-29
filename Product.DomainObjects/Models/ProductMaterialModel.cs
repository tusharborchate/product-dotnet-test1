using System;

namespace Product.DomainObjects.Models
{
    public class ProductMaterialModel
    {
        public Decimal Quantity { get; set; }
        public String MaterialName { get; set; }
        public Int32 MaterialId { get; set; }
    }
}