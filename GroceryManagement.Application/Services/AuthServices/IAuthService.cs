using GroceryManagement.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Application.Services.AuthServices
{
    public interface IAuthService
    {
        public string GenerateToken(UserDTO userDTO);
    }
}
