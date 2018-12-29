using System;
using System.Collections.Generic;

namespace Product.Data.Repositories
{
    public interface IProductRepository
    {
        Entities.Product GetById(Int32 id);
        IList<Entities.Product> GetAll();
        void Update(Int32 id, String name, Decimal price);
        void Delete(Int32 id);
       }
}