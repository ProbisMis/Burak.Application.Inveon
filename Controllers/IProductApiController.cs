using Burak.Application.Inveon.Data.EntityModels;
using Burak.Application.Inveon.Models.Request;
using Burak.Application.Inveon.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Burak.Application.Inveon
{
    public interface IProductApiController
    {
        Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request);

        Task<UpdateProductResponse> GetProductBySku(string sku);

        Task<List<UpdateProductResponse>> GetProducts();

        Task DeleteItem(UpdateProductRequest request);
   
    }
}