using GroceryManagement.Application.Abstractions.IRepositories;
using GroceryManagement.Domain.Entities.Models;
using GroceryManagement.Infrastructure.BaseRepositories;
using GroceryManagement.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(GroceryManagementDbContext cont)
        : base(cont)
        { }
    }
}
