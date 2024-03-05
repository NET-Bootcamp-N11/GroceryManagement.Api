using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GroceryManagement.Domain.Entities.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public IFormFile picture { get; set; }
    }
}
