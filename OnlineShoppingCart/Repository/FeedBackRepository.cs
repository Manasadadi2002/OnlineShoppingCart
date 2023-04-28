using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Repository
{
    public class FeedBackRepository:IFeedBackRepository
    {
        private readonly ShoppingDbContext shoppingDb;
        public FeedBackRepository(ShoppingDbContext shoppingDb)
        {
            this.shoppingDb = shoppingDb;
        }
        public async Task<FeedBack> AddAsync(FeedBack feedback)
        {
            await shoppingDb.AddAsync(feedback);
            await shoppingDb.SaveChangesAsync();
            return feedback;
        }
        public async Task<IEnumerable<FeedBack>> GetAllAsync()
        {
            var feedback = await shoppingDb.FeedBack.ToListAsync();
            return feedback;
        }
        public async Task<FeedBack> GetAsync(int id)
        {
            return await shoppingDb.FeedBack.FirstOrDefaultAsync(x => x.UserId == id);
        }
    }
}
