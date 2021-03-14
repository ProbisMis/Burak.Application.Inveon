using System.Threading.Tasks;
using AutoMapper;
using Burak.Application.Inveon.Controllers;
using Burak.Application.Inveon.Data.EntityModels;
using Burak.Application.Inveon.Models.Request;
using Burak.Application.Inveon.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Burak.Application.Inveon.Pages.Admin.Products
{
    public class AdminDetailsModel : PageModel
    {
        private readonly IProductApiController _productApiController;
        private readonly IMapper _mapper;

        [BindProperty]
        public UpdateProductRequest ProductRequest { get; set; }

        [BindProperty]
        public UpdateProductResponse ProductResponse { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Uid { get; set; }

        public AdminDetailsModel(IProductApiController productApiController, IMapper mapper)
        {
            _productApiController = productApiController;
            _mapper = mapper;
        }

        public async Task OnGetAsync(string uid)
        {
            ProductResponse = await _productApiController.GetProductBySku(Uid);

            ProductRequest = _mapper.Map<UpdateProductRequest>(ProductResponse);

        }

        public async Task<IActionResult> OnPostAsync()
        {
           
            ProductResponse = await _productApiController.UpdateProduct(ProductRequest);

            ProductRequest = _mapper.Map<UpdateProductRequest>(ProductResponse);

            return this.RedirectToPage("/Admin/Products/Index");
        }
    }
}