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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _order;
        public OrderController(IOrderRepository order)
        {
            _order = order;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var order = await _order.GetAllAsync();
            return Ok(order);
        }
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetproductAsync")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var order = await _order.GetAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> AddAsync(Order addorder)
        {
            var order = new Models.Order()
            {
                UserId = addorder.UserId,
                ProductId = addorder.ProductId,
                ProductName = addorder.ProductName,
                ProductImage = addorder.ProductImage,
                Quantity = addorder.Quantity,
                Price = addorder.Price,


            };
            await _order.AddAsync(order);
            return Ok(new { message = "Added order SuccessFully" });
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var employeeid = await _order.DeleteAsync(id);
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
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] Order updateorder)
        {
            try
            {
                var order = new Models.Order()
                {
                    UserId = updateorder.UserId,
                    ProductId = updateorder.ProductId,
                    ProductName = updateorder.ProductName,
                    ProductImage = updateorder.ProductImage,
                    Quantity = updateorder.Quantity,
                    Price = updateorder.Price,

                };
                order = await _order.UpdateAsync(id, order);
                if (order == null)
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
