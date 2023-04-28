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
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cart;
        public CartController(ICartRepository cart)
        {
            _cart = cart;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cart = await _cart.GetAllAsync();
            return Ok(cart);
        }
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetproductAsync")]
        public async Task<IActionResult> GetAsync(int Cartid)
        {
            var cart = await _cart.GetAsync(Cartid);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }
        [HttpPost]
        [Route("AddCart")]
        public async Task<IActionResult> AddAsync(Cart addcart)
        {
            var cart = new Models.Cart()
            {
                UserId = addcart.UserId,
                ProductId=addcart.ProductId,
                ProductName=addcart.ProductName,
                ProductImage=addcart.ProductImage,
                Quantity=addcart.Quantity,
                Price = addcart.Price,
               

            };
            await _cart.AddAsync(cart);
            return Ok(new { message = "Added cart SuccessFully" });
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int Cartid)
        {
            try
            {
                var employeeid = await _cart.DeleteAsync(Cartid);
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
        public async Task<IActionResult> UpdateAsync([FromRoute] int Cartid, [FromBody] Cart updatecart)
        {
            try
            {
                var cart = new Models.Cart()
                {
                    UserId = updatecart.UserId,
                    ProductId = updatecart.ProductId,
                    ProductName = updatecart.ProductName,
                    ProductImage = updatecart.ProductImage,
                    Quantity = updatecart.Quantity,
                    Price = updatecart.Price,

                };
                cart = await _cart.UpdateAsync(Cartid, cart);
                if (cart == null)
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
