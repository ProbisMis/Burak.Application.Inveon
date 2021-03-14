using Burak.Application.Inveon.Data;
using Burak.Application.Inveon.Data.EntityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProductService> _logger;

        public ProductService(DataContext dataContext,
            IConfiguration configuration, ILogger<ProductService> logger)
        {
            _dataContext = dataContext;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<Product> CreateProduct(Product Product)
        {
            var addedProduct = _dataContext.Products.Add(Product);
            await _dataContext.SaveChangesAsync();

            return addedProduct.Entity;
        }

        public async Task<IList<Product>> GetAll()
        {
            var Products = _dataContext.Products;

            return Products.ToList();
        }

        public async Task<Product> GetProductById(int ProductId)
        {
            var Product = _dataContext.Products.Find(ProductId);

            return Product;
        }

        public async Task<Product> GetProductBySku(string Sku)
        {
            var Product = _dataContext.Products.
                                 Where(x => x.SKU.Equals(Sku)).FirstOrDefault();

            return Product;
        }

        public async Task<Product> UpdateProduct(Product Product)
        {
            var updatedProduct = _dataContext.Products.Update(Product);
            await _dataContext.SaveChangesAsync();

            return updatedProduct.Entity;
        }

        public async Task DeleteProduct(Product Product)
        {
            var updatedProduct = _dataContext.Products.Remove(Product);
            await _dataContext.SaveChangesAsync();
        }
    }
}
