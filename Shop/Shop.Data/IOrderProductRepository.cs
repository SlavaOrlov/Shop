using Shop.Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data
{
    public interface IOrderProductRepository
    {
        DataWrapper<ProductDto> ProductAdd(ProductDto productDto);
        DataWrapper<ProductDto> ProductGetById(int id);
        DataWrapper<List<ProductDto>> ProductGetAll();
        DataWrapper<ProductDto> ProductUpdate(ProductDto productDto);
        DataWrapper<int> OrderAdd(OrderDto orderDto);
        DataWrapper<OrderDto> OrderGetById(int id);
        DataWrapper<int> OrderProductAdd(OrderProductDto orderProductDto);
        DataWrapper<OrderDto> CreateFullOrder(OrderDto orderDto);
    }
}
