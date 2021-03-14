using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Burak.Application.Inveon.Business.Services;
using Burak.Application.Inveon.Controllers;
using Burak.Application.Inveon.Data.EntityModels;
using Burak.Application.Inveon.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Burak.Application.Inveon.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductApiController _productApiController;
        
        [BindProperty(SupportsGet = true)]
        public string SKU { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 6;
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public int TotalPages => (int) Math.Ceiling(decimal.Divide(Products?.Count ?? 0, PageSize));

        public List<UpdateProductResponse> Products { get; set; }

        public IndexModel(IProductApiController productApiController)
        {
            _productApiController = productApiController;
        }

        public async Task OnGetAsync(string SKU)
        {
            Products = await _productApiController.GetProducts();
        }
    }
}