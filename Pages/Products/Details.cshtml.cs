using System.Threading.Tasks;
using Burak.Application.Inveon.Controllers;
using Burak.Application.Inveon.Data.EntityModels;
using Burak.Application.Inveon.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Burak.Application.Inveon.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductApiController _productApiController;

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public UpdateProductResponse ProductResponse { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Uid { get; set; }

        public DetailsModel(IProductApiController productApiController)
        {
            _productApiController = productApiController;
        }

        public async Task OnGetAsync(string uid)
        {
            ProductResponse = await _productApiController.GetProductBySku(Uid);
        }
    }
}