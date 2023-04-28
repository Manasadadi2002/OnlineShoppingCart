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
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _address;
        public AddressController(IAddressRepository address)
        {
            _address = address;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var address = await _address.GetAllAsync();
            return Ok(address);
        }
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetproductAsync")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var address = await _address.GetAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }
        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> AddAsync(Address addaddress)
        {
            var address = new Models.Address()
            {
                UserId = addaddress.UserId,
                AddressInfo = addaddress.AddressInfo,
                City = addaddress.City,
                State = addaddress.State,
                Pincode = addaddress.Pincode,
              


            };
            await _address.AddAsync(address);
            return Ok(new { message = "Added address SuccessFully" });
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var employeeid = await _address.DeleteAsync(id);
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
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] Address updateaddress)
        {
            try
            {
                var address = new Models.Address()
                {
                    UserId = updateaddress.UserId,
                    AddressInfo=updateaddress.AddressInfo,
                    City=updateaddress.City,
                    State=updateaddress.State,
                    Pincode=updateaddress.Pincode,

                   

                };
                address = await _address.UpdateAsync(id, address);
                if (address == null)
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
