using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyPractices1
{
    public interface IProductRepository
    {
       public IEnumerable<Product> GetAllProducts();
       public void CreateProduct(string name, double price, int categoryID);
        public void UpdateProduct(int ProductID, double updatedPrice);
        public void DeleteProduct(int ProductID);

    }
}
