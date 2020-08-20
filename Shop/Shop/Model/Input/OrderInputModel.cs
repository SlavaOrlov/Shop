using Shop.Data.DTO;
using System.Collections.Generic;

namespace Shop.Api.Model.Input
{
    public class OrderInputModel
    {
        public string Fio { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public List<ProductDto> ProductDto { get; set; }
    }
}
