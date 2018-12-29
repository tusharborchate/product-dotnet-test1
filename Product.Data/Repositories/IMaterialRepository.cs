using System;
using System.Collections.Generic;
using Product.Data.Entities;

namespace Product.Data.Repositories
{
    public interface IMaterialRepository
    {
        Material GetById(Int32 id);
        IList<Material> GetAll();
        void Update(Int32 id, String name, Decimal cost);
        void Delete(Int32 id);
        ICollection<Entities.ProductMaterial> GetProductsByMaterialId(int materialId);
        bool UpdateProductMaterial(Entities.ProductMaterial productMaterial);
        Entities.ProductMaterial GetProductMaterialByProductIdMaterialId(int productId, int materialId);
    }
}