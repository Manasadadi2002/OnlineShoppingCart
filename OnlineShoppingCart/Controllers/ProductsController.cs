using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCart.Models;
using OnlineShoppingCart.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _product;
        public ProductsController(IProductRepository product)
        {
            _product = product;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await _product.GetAllAsync();
            return Ok(product); 
        }
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetproductAsync")]
        public async Task<IActionResult> GetAsync(int id) 
        {
            var product = await _product.GetAsync(id);
            if (product == null)
            { 
                return NotFound();
            } 
            return Ok(product); 
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddAsync(Product addproduct)
        {
            var product = new Models.Product()
            {
                Category = addproduct.Category,
                ProductName = addproduct.ProductName,
                Price = addproduct.Price,
                Description = addproduct.Description,
                ProductImage=addproduct.ProductImage,
               
        };
            await _product.AddAsync(product);
            return Ok(new { message = "Added products SuccessFully" });
        }
        [HttpDelete] 
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            { 
                var employeeid = await _product.DeleteAsync(id);
                if (employeeid == null)
                {
                    return NotFound(); 
                } 
            } 
            catch (Exception)
            { }
            return Ok("Deleted SuccessFully");
        }
        [HttpPut] 
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] Product updateproduct) 
        {
            try
            {
                var product = new Models.Product() 
                {
                    Category = updateproduct.Category,
                    ProductName = updateproduct.ProductName,
                    Price = updateproduct.Price,
                    Description = updateproduct.Description,
                    ProductImage=updateproduct.ProductImage,
                   
                }; 
                product = await _product.UpdateAsync(id, product);
                if (product == null)
                {
                    return NotFound(); 
                }
            } 
            catch (Exception) 
            { } 
            return Ok("Updated Successfully"); 
        }
    }
}
