using Dapper;
using Shop.Data.DTO;
using Shop.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Options;
using System.Xml;

namespace Shop.Data
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly IDbConnection _connection;
        Categorization categorization;
        public OrderProductRepository(IOptions<DatabaseOptions> options)
        {
            _connection = new SqlConnection(options.Value.DbConnectionString);
            categorization = new Categorization();
        }
        public DataWrapper<OrderDto> CreateFullOrder(OrderDto orderDto)
        {
            var orderProduct = new OrderProductDto();
            var result = new DataWrapper<OrderDto>();
            try
            {
                orderDto.Id = OrderAdd(orderDto).Data;
                foreach (var product in orderDto.ProductDto)
                {
                    orderProduct.OrderId = orderDto.Id.Value;
                    orderProduct.ProductId = product.Id;
                    orderProduct.Quantity = orderDto.Quantity;
                    OrderProductAdd(orderProduct);
                }
                result.Data = OrderGetById(orderDto.Id.Value).Data;
                result.IsOk = true;
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }
        public DataWrapper<int> OrderAdd(OrderDto orderDto)
        {
            var result = new DataWrapper<int>();
            try
            {
                string sqlExpression = "Order_Add";
                result.Data = _connection.Query<int>(sqlExpression, new
                {
                    orderDto.Id,
                    orderDto.Fio,
                    orderDto.Address
                },
                commandType: CommandType.StoredProcedure).FirstOrDefault();
                result.IsOk = true;
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }
        public DataWrapper<OrderDto> OrderGetById(int id)
        {
            var orderDictionary = new Dictionary<int, OrderDto>();
            var result = new DataWrapper<OrderDto>();
            try
            {
                string sqlExpression = "Order_GetById";
                result.Data = _connection.Query<OrderDto, OrderProductDto, ProductDto, OrderDto>(
                    sqlExpression,
                    (order, orderProduct, product) =>
                    {
                        OrderDto orderEntry;
                        if (!orderDictionary.TryGetValue(order.Id.Value, out orderEntry))
                        {
                            orderEntry = order;
                            orderEntry.ProductDto = new List<ProductDto>();
                            orderDictionary.Add(orderEntry.Id.Value, orderEntry);
                        }
                        orderEntry.Quantity = orderProduct.Quantity;
                        orderEntry.ProductDto.Add(product);
                        return orderEntry;
                    },
                    new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                result.IsOk = true;
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }

        public DataWrapper<int> OrderProductAdd(OrderProductDto orderProductDto)
        {
            var result = new DataWrapper<int>();
            try
            {
                string sqlExpression = "Order_Product_Add";
                result.Data = _connection.Query<int>(sqlExpression, 
                    new
                    {
                        orderProductDto.OrderId,
                        orderProductDto.ProductId,
                        orderProductDto.Quantity
                    },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                result.IsOk = true;
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }
        public DataWrapper<ProductDto> ProductAdd(ProductDto productDto)
        {
            var result = new DataWrapper<ProductDto>();
            try
            {
                string sqlExpression = "Product_Add";
                var product = _connection.Query<ProductDto>(sqlExpression,productDto,commandType: CommandType.StoredProcedure).FirstOrDefault();
                result.Data = categorization.AddCategoryForWhatProduct(new List<ProductDto>() { product }).FirstOrDefault();
                result.IsOk = true;
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }
        public DataWrapper<List<ProductDto>> ProductGetAll()
        {
            var result = new DataWrapper<List<ProductDto>>();
            try
            {
                string sqlExpression = "Product_GetAll";
                var products = _connection.Query<ProductDto>(sqlExpression).ToList();
                result.Data = categorization.AddCategoryForWhatProduct(products);
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }

        public DataWrapper<ProductDto> ProductGetById(int id)
        {
            var result = new DataWrapper<ProductDto>();
            try
            {
                string sqlExpression = "Product_GetById";
                var products = _connection.Query<ProductDto>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                result.Data = categorization.AddCategoryForWhatProduct(new List<ProductDto>() { products }).FirstOrDefault();
                result.IsOk = true;
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }

        public DataWrapper<ProductDto> ProductUpdate(ProductDto productDto)
        {
            var result = new DataWrapper<ProductDto>();
            try
            {
                string sqlExpression = "Product_Update";
                var product = _connection.Query<ProductDto>(sqlExpression,productDto,commandType: CommandType.StoredProcedure).FirstOrDefault();
                result.Data = categorization.AddCategoryForWhatProduct(new List<ProductDto>() { product }).FirstOrDefault();
                result.IsOk = true;
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }
    }
}
