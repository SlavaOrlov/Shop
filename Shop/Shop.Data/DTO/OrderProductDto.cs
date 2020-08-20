using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.DTO
{
    public class OrderProductDto
    {
        public int? Id { get; set; }
        public int OrderId { get; set; }
        public int  ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
