using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Burak.Application.Inveon.Business.Services;
using Burak.Application.Inveon.Controllers;
using Burak.Application.Inveon.Data.EntityModels;
using Burak.Application.Inveon.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Burak.Application.Inveon.Pages.Admin.Products
{
    public class AdminIndexModel : PageModel
    {
        private readonly IProductApiController _productApiController;
        private readonly IMapper _mapper;

        [BindProperty(SupportsGet = true)]
        public string SKU { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 6;
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public int TotalPages => (int) Math.Ceiling(decimal.Divide(Products?.Count ?? 0, PageSize));

        public List<UpdateProductResponse> Products { get; set; }

        public AdminIndexModel(IProductApiController productApiController, IMapper mapper)
        {
            _productApiController = productApiController;
            _mapper = mapper;
        }

        public async Task OnGetAsync(string SKU)
        {
            Products = await _productApiController.GetProducts();
        }
    }
}