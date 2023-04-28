using OnlineShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetAsync(int id);
        Task<Order> AddAsync(Order entity);
        Task<Order> DeleteAsync(int id);
        Task<Order> UpdateAsync(int id, Order entity);
    }
}
