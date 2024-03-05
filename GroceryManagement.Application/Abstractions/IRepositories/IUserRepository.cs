using GroceryManagement.Application.Abstractions.IBaseRepositories;
using GroceryManagement.Domain.Entities.Models;

namespace GroceryManagement.Application.Abstractions.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
