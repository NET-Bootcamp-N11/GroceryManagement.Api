using GroceryManagement.Domain.Entities.DTOs;
using GroceryManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Application.IServices
{
    public interface IProductService
    {
        public string Create(ProductDTO productDTO);
        public IEnumerable<Product> GetAll();
        public Product GetByName(string name);
        public string Update(int id, ProductDTO productDTO);
        public string Delete(int id);
    }
}
