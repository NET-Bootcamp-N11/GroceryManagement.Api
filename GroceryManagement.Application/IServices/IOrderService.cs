using GroceryManagement.Domain.Entities.DTOs;
using GroceryManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Application.IServices
{
    public interface IOrderService
    {
        public string Create(OrderDTO orderDTO);
        public IEnumerable<Order> GetAll();
        public Order GetByName(string name);
        public string Update(int id, OrderDTO orderDTO);
        public string Delete(int id);
    }
}
