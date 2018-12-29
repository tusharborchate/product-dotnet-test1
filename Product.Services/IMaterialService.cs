using System;
using System.Collections.Generic;
using Product.DomainObjects.Models;

namespace Product.Services
{
    public interface IMaterialService
    {
        MaterialModel GetById(Int32 id);
        IList<MaterialModel> GetAll();
        bool Merge(Int32 materialIdToKeep, Int32 materialIdToDelete);

    }
}