using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Data.Entities
{
    public class ProductMaterial
    {
        [Key]
        public Int32 ProductMaterialId { get; set; }

        public Decimal Quantity { get; set; }

        public Int32 ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        
        [ForeignKey("MaterialId")]
        public Material Material { get; set; }

        public Int32 MaterialId { get; set; }
    }
}