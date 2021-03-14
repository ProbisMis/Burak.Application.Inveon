using AutoMapper;
using Burak.Application.Inveon.Data.EntityModels;
using Burak.Application.Inveon.Models.Request;
using Burak.Application.Inveon.Models.Response;

namespace Burak.Application.Inveon.Business.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper() {
            base.CreateMap<UpdateProductRequest, Product>().ReverseMap();
            base.CreateMap<UpdateProductResponse, Product>().ReverseMap();
            base.CreateMap<UpdateProductResponse, UpdateProductRequest>().ReverseMap();
        }
        
    }
}
