using System;
using System.Collections.Generic;
using System.Linq;
using Product.Data.Context;
using Product.Data.Entities;

namespace Product.Data.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ProductDataContext _context;
        public MaterialRepository(ProductDataContext context)
        {
            _context = context;
        }

        public Material GetById(Int32 id)
        {
            return _context.Materials.FirstOrDefault(x => x.MaterialId == id);
        }

        public IList<Material> GetAll()
        {
            try
            {
            List<Material> materials = new List<Material>();
             materials= _context.Materials.ToList();
            return materials;
            }
            catch (Exception ex)
            {
                //log ex
                throw ex;
            }
           
        }

        public void Update(Int32 id, String name, Decimal cost)
        {
            var entity = _context.Materials.First(x => x.MaterialId == id);
            entity.Name = name;
            entity.Cost = cost;
        }

        public void Delete(Int32 id)
        {
            var entity = _context.Materials.First(x => x.MaterialId == id);
            _context.Materials.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// get all product and materials using material id
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public ICollection<Entities.ProductMaterial> GetProductsByMaterialId(int materialId)
        {
            return _context
                   .ProductMaterials.Where(a => a.MaterialId == materialId).ToList();

        }

        /// <summary>
        /// get product material by product id and material id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="materialId"></param>
        /// <returns></returns>        
        public Entities.ProductMaterial GetProductMaterialByProductIdMaterialId(int productId,int materialId)
        {
            return _context
                   .ProductMaterials.Where(a => a.MaterialId == materialId && a.ProductId==productId).FirstOrDefault();

        }



        /// <summary>
        ///      update product material
        /// </summary>
        /// <param name="productMaterial"></param>
        /// <returns>boolean</returns>
        public bool UpdateProductMaterial(Entities.ProductMaterial productMaterial)
        {
            bool result = false;
            try
            {
                var entity = _context.ProductMaterials.First(x => x.ProductMaterialId == productMaterial.ProductMaterialId);
                entity = productMaterial;
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {

                //log error

            }
            return result;
        }



    }
}