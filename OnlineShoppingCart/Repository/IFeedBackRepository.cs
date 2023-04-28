using OnlineShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Repository
{
    public interface IFeedBackRepository
    {
        Task<IEnumerable<FeedBack>> GetAllAsync();
        Task<FeedBack> GetAsync(int id);
        Task<FeedBack> AddAsync(FeedBack entity);
    }
}
