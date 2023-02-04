using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dapper_ORM_
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public DapperProductRepository()
        {

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;").ToList();
        }
        public void InsertProduct(string Name, double Price, int CategoryID)
        {
            _connection.Execute("insert into products (Name, Price, CategoryID) Values (@Name,@Price,@CategoryID);",
                new { Name = Name, Price = Price, CategoryID = CategoryID }) ;
                           
        }
        public void DeleteProduct (int ProductId)
        {
            _connection.Execute("Delete From products where (@ProductID) = (ProductId);",
                new { ProductId = ProductId }) ;

        }

    }
}
