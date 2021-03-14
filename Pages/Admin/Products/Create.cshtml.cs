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
    public class AdminCreateModel : PageModel
    {
        private readonly IProductApiController _productApiController;
        private readonly IMapper _mapper;

        [BindProperty]
        public UpdateProductRequest ProductRequest { get; set; }

        [BindProperty]
        public UpdateProductResponse ProductResponse { get; set; }

        public AdminCreateModel(IProductApiController productApiController, IMapper mapper)
        {
            _productApiController = productApiController;
            _mapper = mapper;
        }

        public async Task OnGetAsync()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
           
            ProductResponse = await _productApiController.CreateProduct(ProductRequest);

            ProductRequest = _mapper.Map<UpdateProductRequest>(ProductResponse);

            return this.RedirectToPage("/Admin/Products/Index");
        }
    }
}