using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Data.Entities
{
    public class Product
    {
        [Key]
        public Int32 ProductId { get; set; }

        public String Name { get; set; }

        public Decimal Price { get; set; }

        [InverseProperty("Product")]
        public ICollection<ProductMaterial> ProductMaterials { get; set; }
    }
}