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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _payment;
        public PaymentController(IPaymentRepository payment)
        {
            _payment = payment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payment = await _payment.GetAllAsync();
            return Ok(payment);
        }
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetproductAsync")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var payment = await _payment.GetAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }
        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> AddAsync(Payment addpayment)
        {
            var payment = new Models.Payment()
            {
                TransactionAmount=addpayment.TransactionAmount,
                UserId = addpayment.UserId,
                OrderId=addpayment.OrderId,
                Tstatus=addpayment.Tstatus,
                Mode=addpayment.Mode,
                Code=addpayment.Code,

                


            };
            await _payment.AddAsync(payment);
            return Ok(new { message = "Added payment SuccessFully" });
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var employeeid = await _payment.DeleteAsync(id);
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
        public async Task<IActionResult> UpdateAsync([FromRoute] int Transactionid, [FromBody] Payment updatepayment)
        {
            try
            {
                var payment = new Models.Payment()
                {
                    TransactionAmount = updatepayment.TransactionAmount,
                    UserId = updatepayment.UserId,
                    OrderId = updatepayment.OrderId,
                    Tstatus = updatepayment.Tstatus,
                    Mode = updatepayment.Mode,
                    Code = updatepayment.Code,

                };
                payment = await _payment.UpdateAsync(Transactionid, payment);
                if (payment == null)
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
