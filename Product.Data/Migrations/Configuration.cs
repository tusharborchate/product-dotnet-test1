using System.Collections.Generic;
using Product.Data.Context;
using Product.Data.Entities;

namespace Product.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private Material UpsertMaterial(ProductDataContext context, Material entity)
        {
            var existing = context.Materials.FirstOrDefault(x => x.Name == entity.Name);
            if (existing != null)
            {
                return existing;
            }

            entity = context.Materials.Add(entity);
            context.SaveChanges();

            return entity;
        }

        private void UpsertProduct(ProductDataContext context, Entities.Product entity)
        {
            var existing = context.Products.FirstOrDefault(x => x.Name == entity.Name);
            if (existing != null)
            {
                return;
            }
            entity = context.Products.Add(entity);

            foreach (var productMaterial in entity.ProductMaterials)
            {
                var existingProductMaterial = context.ProductMaterials.FirstOrDefault(x => x.Quantity == productMaterial.Quantity && x.ProductId == productMaterial.ProductId && x.MaterialId == productMaterial.MaterialId);

                if (existingProductMaterial == null)
                {
                    context.ProductMaterials.Add(productMaterial);
                }
            }

            context.SaveChanges();
        }

        protected override void Seed(ProductDataContext context)
        {
            var box1 = UpsertMaterial(context, new Material
            {
                Name = "Box 1",
                Cost = 0.25m
            });
            
            var box2 = UpsertMaterial(context, new Material
            {
                Name = "Box 2",
                Cost = 0.25m
            });

            var label1 = UpsertMaterial(context, new Material
            {
                Name = "Toy Car Label",
                Cost = 0.01m
            });

            var label2 = UpsertMaterial(context, new Material
            {
                Name = "Train Set Label",
                Cost = 0.01m
            });

            var products = new[]
            {
                new Entities.Product
                {
                    Name = "Toy Car",
                    Price = 10.00m,
                    ProductMaterials = new List<ProductMaterial>()
                    {
                        new ProductMaterial() { MaterialId = label1.MaterialId, Quantity =  2 },
                        new ProductMaterial() { MaterialId = box1.MaterialId, Quantity =  1 }
                    }
                },

                new Entities.Product
                {
                    Name = "Train Set",
                    Price = 100.00m,
                    ProductMaterials = new List<ProductMaterial>()
                    {
                        new ProductMaterial() { MaterialId = label2.MaterialId, Quantity =  2 },
                        new ProductMaterial() { MaterialId = box2.MaterialId, Quantity =  1 }
                    }
                },
            };

            foreach (var p in products)
            {
                UpsertProduct(context, p);
            }
        }
    }
}
