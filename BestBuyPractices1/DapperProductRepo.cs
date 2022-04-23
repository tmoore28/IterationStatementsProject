using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;

namespace BestBuyPractices1
{
    public class DapperProductRepo : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepo(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
          _connection.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categotyID);", 
              new { name = name, price = price, categoryID = categoryID });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM products WHERE ProductID = @productID ",
                new { productID = productID });
            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID ",

                new { productID = productID });
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID ",

                new { productID = productID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public void UpdateProduct(int ProductID, double updatedPrice)
        {
            _connection.Execute("UPDATE products SET Price = @updatedPrice WHERE ProductID = @productID;",
                new { ProductID = ProductID, updatedPrice = updatedPrice });

            Console.WriteLine("Product Updated");
            Thread.Sleep(3000);
        }
    }
}
