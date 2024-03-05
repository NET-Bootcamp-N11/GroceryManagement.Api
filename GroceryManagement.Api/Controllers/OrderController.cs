using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GroceryManagement.Application.IServices;
using GroceryManagement.Domain.Entities.DTOs;
using GroceryManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using GroceryManagement.Api.Atribitues;
using GroceryManagement.Domain.Entities.Enums;

namespace GroceryManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetAllOrder)]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetByNameOrder)]
        public ActionResult<Order> GetOrderByName(string ownerName)
        {
            var order = _orderService.GetByName(ownerName);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        [IdentityFilter(Permissions.CreateOrder)]
        public ActionResult<string> CreateOrder(OrderDTO orderDTO)
        {
            var result = _orderService.Create(orderDTO);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [IdentityFilter(Permissions.UpdateOrder)]
        public ActionResult<string> UpdateOrder(int id, OrderDTO orderDTO)
        {
            var result = _orderService.Update(id, orderDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [IdentityFilter(Permissions.DeleteOrder)]
        public ActionResult<string> DeleteOrder(int id)
        {
            var result = _orderService.Delete(id);
            return Ok(result);
        }
    }
}
