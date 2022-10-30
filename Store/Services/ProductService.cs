using Microsoft.EntityFrameworkCore;
using Store.DataAccess;
using Store.Entities;
using Store.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDpContext _dbContext;
        public ProductService(AppDpContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public Product GetProductById(int id)
        {
            var result = _dbContext.Products.Include(p=>p.Category).FirstOrDefault(p => p.Id == id);
            if (result == null) throw new Exception("Product not found");
            return result;
        }

        public List<Product> GetProducts()
        {
            return _dbContext.Products.Include(p => p.Category).ToList();
        }

        public List<Product> GetProductsByCategoryId(int CategoryId)
        {
            return _dbContext.Products.Where(p=>p.CategoryId == CategoryId).Include(p => p.Category).ToList();
        }

        public Product UpdateProduct(int productId, Product product)
        {
            if (!(productId > 0)) throw new Exception("Product Id not provided");
            var productToEdit = GetProductById(productId);
            productToEdit.Name = product.Name;
            productToEdit.Price = product.Price;
            productToEdit.Quantity = product.Quantity;
            productToEdit.ImgURL = product.ImgURL;
            productToEdit.CategoryId = product.CategoryId;
            _dbContext.Entry(productToEdit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return productToEdit;
        }
    }
}
