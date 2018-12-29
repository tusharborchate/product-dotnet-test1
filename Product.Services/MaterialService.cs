using System;
using System.Collections.Generic;
using System.Linq;
using Product.Data.Repositories;
using Product.DomainObjects.Models;

namespace Product.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public MaterialModel GetById(Int32 id)
        {
            return Transfer(_materialRepository.GetById(id));
        }

        public IList<MaterialModel> GetAll()
        {
            return _materialRepository.GetAll().Select(Transfer).ToList();
        }

        /// <summary>
        /// please note that I have changed void return type to bool to tell user if its merged or not.
        /// </summary>
        /// <param name="materialIdToKeep"></param>
        /// <param name="materialIdToDelete"></param>
        /// <returns></returns>
        public bool Merge(Int32 materialIdToKeep, Int32 materialIdToDelete)
        {
            bool result = false;
            try
            {
                //here we are passing materialtoDelete to get products by materialtodelete
                ICollection<Data.Entities.ProductMaterial> productMaterialModelList = _materialRepository.GetProductsByMaterialId(materialIdToDelete);

                //writing logic here

                foreach (var item in productMaterialModelList)
                {
                    //product material to update quantity
                    Data.Entities.ProductMaterial productMaterial = _materialRepository.GetProductMaterialByProductIdMaterialId(item.ProductId, materialIdToKeep);
                    if (productMaterial != null)
                    { 
                    productMaterial.Quantity = productMaterial.Quantity + item.Quantity;
                    result = _materialRepository.UpdateProductMaterial(productMaterial);
                        if (!result)
                        {
                            return false;
                        }
                        result = true;
                    }
                    //if different product then don't update quantity
                    else
                    {
                        item.MaterialId = materialIdToKeep;
                        result = _materialRepository.UpdateProductMaterial(item);

                    }
                }

                //delete material
                _materialRepository.Delete(materialIdToDelete);


            }
            catch (Exception ex)
            {

                //log ex

            }
            return result;
        }

        private MaterialModel Transfer(Data.Entities.Material entity)
        {
            return new MaterialModel
            {
                MaterialId = entity.MaterialId,
                Name = entity.Name,
                Cost = entity.Cost
            };
        }

       
    }
}