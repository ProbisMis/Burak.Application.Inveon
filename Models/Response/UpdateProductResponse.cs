using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Models.Response
{
    public class UpdateProductResponse
    {
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
