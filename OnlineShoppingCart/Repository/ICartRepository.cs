using OnlineShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Repository
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetAllAsync();
        Task<Cart> GetAsync(int cartid);
        Task<Cart> AddAsync(Cart entity);
        Task<Cart> DeleteAsync(int Cartid);
        Task<Cart> UpdateAsync(int Cartid, Cart entity);
    }
}
