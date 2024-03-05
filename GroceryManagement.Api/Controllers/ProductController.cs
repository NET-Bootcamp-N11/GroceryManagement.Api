using GroceryManagement.Api.Atribitues;
using GroceryManagement.Application.IServices;
using GroceryManagement.Domain.Entities.DTOs;
using GroceryManagement.Domain.Entities.Enums;
using GroceryManagement.Domain.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnv;

        public ProductController(IProductService productService,IWebHostEnvironment webHostEnv)
        {
            _productService = productService;
            _webHostEnv = webHostEnv;
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetAllProduct)]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetByNameProduct)]
        public ActionResult<Product> GetProductByName(string name)
        {
            var product = _productService.GetByName(name);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetPictureProduct)]
        public IActionResult GetProductPicture(string name)
        {
            Product product=_productService.GetByName(name);
            byte[] fileBytes = System.IO.File.ReadAllBytes(product.Path);
            return File(fileBytes, "image/jpeg");
        }

        [HttpPost]
        [IdentityFilter(Permissions.CreateProduct)]
        public ActionResult<string> CreateProduct(ProductDTO productDTO)
        {
            var result = _productService.Create(productDTO);
            string path = Path.Combine(_webHostEnv.WebRootPath, "images", productDTO.picture.FileName);
            using(FileStream stream =new FileStream(path,FileMode.Create))
            {
                productDTO.picture.CopyTo(stream);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        [IdentityFilter(Permissions.UpdateProduct)]
        public ActionResult<string> UpdateProduct(int id, ProductDTO productDTO)
        {
            var result = _productService.Update(id, productDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [IdentityFilter(Permissions.DeleteProduct)]
        public ActionResult<string> DeleteProduct(int id)
        {
            var result = _productService.Delete(id);
            return Ok(result);
        }
    }
}
