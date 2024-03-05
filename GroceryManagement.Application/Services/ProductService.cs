using GroceryManagement.Application.Abstractions.IRepositories;
using GroceryManagement.Application.IServices;
using GroceryManagement.Domain.Entities.DTOs;
using GroceryManagement.Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public string Create(ProductDTO productDTO)
        {
            Product product = new Product()
            {
                Name = productDTO.Name,
                Category = productDTO.Category,
                ExpireDate = DateTime.UtcNow.AddMonths(12),
                Path = "D:\\sharp\\GroceryManagement.Api\\GroceryManagement.Api\\wwwroot\\images\\"+ productDTO.picture.FileName
            };
            return _productRepository.Create(product);
        }
    
        public string Delete(int id)
        {
            return _productRepository.Delete(x=>x.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetByName(string name)
        {
            return _productRepository.GetByAny(x => x.Name == name);
        }


        public string Update(int id, ProductDTO productDTO)
        {
           Product model  = _productRepository.GetByAny(x => x.Id == id);
            model.Name = productDTO.Name;
            model.Category = productDTO.Category;
            return _productRepository.Update(model);
        }
    }
}
