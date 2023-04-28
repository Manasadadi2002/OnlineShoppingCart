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
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedBackRepository _feedback;
    public FeedBackController(IFeedBackRepository feedback)
        {
            _feedback = feedback;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var feedback = await _feedback.GetAllAsync();
            return Ok(feedback);
        }
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetAsync")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var feedback = await _feedback.GetAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }
        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> AddAsync(FeedBack addfeedback)
        {
            var feedback = new Models.FeedBack()
            {
                UserId = addfeedback.UserId,
                EmailId=addfeedback.EmailId,
                feedback=addfeedback.feedback,
                



            };
            await _feedback.AddAsync(feedback);
            return Ok(new { message = "Added feedback SuccessFully" });
        }
    }
}
