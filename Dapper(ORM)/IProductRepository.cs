using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper_ORM_
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        public void CreateProduct(string Name, double Price, int CategoryID)
        {
            
        }

    }
}
