using AutoMapper;
using Burak.Application.Inveon.Business.Services;
using Burak.Application.Inveon.Business.Validator;
using Burak.Application.Inveon.Data.EntityModels;
using Burak.Application.Inveon.Models.CustomExceptions;
using Burak.Application.Inveon.Models.Request;
using Burak.Application.Inveon.Models.Response;
using Burak.Application.Inveon.Utilities.Helper;
using Burak.Application.Inveon.Utilities.ValidationHelper.ValidationResolver;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Controllers
{
    public class ProductApiController : ControllerBase, IProductApiController
    {
        private readonly ILogger<ProductApiController> _logger;
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly IValidatorResolver _validatorResolver;
        private readonly IMapper _mapper;

        public ProductApiController(ILogger<ProductApiController> logger,
            IUserService userService,
            IProductService productService,
            IValidatorResolver validatorResolver,
            IMapper mapper
        )
        {
            _logger = logger;
            _userService = userService;
            _productService = productService;
            _validatorResolver = validatorResolver;
            _mapper = mapper;
        }

        [HttpPost("update")]
        public async Task<UpdateProductResponse> UpdateProduct([FromBody] UpdateProductRequest request)
        {
            /* VALIDATE */
            var validator = _validatorResolver.Resolve<UpdateProductRequestValidator>();
            ValidationResult validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var product = await _productService.GetProductBySku(request.SKU);
            if (ControlHelper.isEmpty(product)) throw new NotFoundException(nameof(Product));

            product.ProductName = request.ProductName;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Quantity = request.Quantity;

            await _productService.UpdateProduct(product);

            var productResponse = _mapper.Map<UpdateProductResponse>(product);

            return productResponse;
        }

        [HttpGet("{sku}")]
        public async Task<UpdateProductResponse> GetProductBySku([FromRoute] string sku)
        {
            if (ControlHelper.isEmpty(sku)) throw new NotFoundException("SKU");

            var product = await _productService.GetProductBySku(sku);
            if (ControlHelper.isEmpty(product)) throw new NotFoundException(nameof(Product));

            var productResponse = _mapper.Map<UpdateProductResponse>(product);

            return productResponse;
        }

        [HttpGet("")]
        public async Task<List<UpdateProductResponse>> GetProducts()
        {
            var products = await _productService.GetAll();
            if (ControlHelper.isEmpty(products)) throw new NotFoundException(nameof(Product));

            var productResponse = _mapper.Map<List<UpdateProductResponse>>(products);

            return productResponse;
        }

        [HttpDelete("delete")]
        public async Task DeleteItem([FromBody] UpdateProductRequest request)
        {
            /* VALIDATE */
            var validator = _validatorResolver.Resolve<UpdateProductRequestValidator>();
            ValidationResult validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }
            var product = await _productService.GetProductBySku(request.SKU);
            if (ControlHelper.isEmpty(product)) throw new NotFoundException(nameof(Product));

            await _productService.DeleteProduct(product);
        }
    }
}
