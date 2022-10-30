using Store.Entities;
using System.Collections.Generic;

namespace Store.Services.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public Product GetProductById(int id);
        public List<Product> GetProductsByCategoryId(int CategoryId);
        public Product AddProduct (Product product);
        public Product UpdateProduct (int productId, Product product);
    }
}
