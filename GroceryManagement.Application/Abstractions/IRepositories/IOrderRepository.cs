using GroceryManagement.Application.Abstractions.IBaseRepositories;
using GroceryManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Application.Abstractions.IRepositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
    }
}
