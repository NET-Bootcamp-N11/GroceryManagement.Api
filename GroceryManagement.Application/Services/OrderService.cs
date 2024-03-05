using GroceryManagement.Application.Abstractions.IRepositories;
using GroceryManagement.Application.IServices;
using GroceryManagement.Domain.Entities.DTOs;
using GroceryManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }
        public string Create(OrderDTO orderDTO)
        {
            Order order = new Order()
            {
                OwnerName = orderDTO.OwnerName,
                ProductName = orderDTO.ProductName,
                BuyTime = DateTime.UtcNow
            };
            return _orderRepository.Create(order);
        }

        public string Delete(int id)
        {
            return _orderRepository.Delete(x => x.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order GetByName(string name)
        {
            return _orderRepository.GetByAny(x => x.OwnerName == name);
        }

        public string Update(int id, OrderDTO orderDTO)
        {
            Order model = _orderRepository.GetByAny(x => x.Id == id);
            model.OwnerName = orderDTO.OwnerName;
            model.ProductName= orderDTO.ProductName;
            model.BuyTime = DateTime.UtcNow;
            return _orderRepository.Update(model);
        }
    }
}
