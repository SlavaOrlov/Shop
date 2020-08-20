using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.DTO
{
    public class OrderDto
    {
        public int? Id { get; set; }
        public string Fio { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public List<ProductDto> ProductDto { get; set; }

    }
}
