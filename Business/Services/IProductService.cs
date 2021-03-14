using Burak.Application.Inveon.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Business.Services
{
    public interface IProductService
    {
        Task<IList<Product>> GetAll();
        Task<Product> GetProductBySku(string Sku);
        Task<Product> CreateProduct(Product Product);
        Task<Product> UpdateProduct(Product Product);
        Task DeleteProduct(Product Product);
    }
}
