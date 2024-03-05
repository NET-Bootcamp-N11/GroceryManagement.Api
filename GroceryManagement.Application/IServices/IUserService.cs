using GroceryManagement.Domain.Entities.DTOs;
using GroceryManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Application.IServices
{
    public interface IUserService
    {
        public string Create(UserDTO userDTO);
        public IEnumerable<User> GetAll();
        public User GetByName(string name);
        public string Update(int id, UserDTO userDTO);
        public string Delete(int id);
        public string SendEmail(UserDTO userDTO, int code);

    }
}
