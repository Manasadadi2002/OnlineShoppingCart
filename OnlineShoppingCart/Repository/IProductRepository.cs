using OnlineShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(int id);
        Task<Product> AddAsync(Product entity); 
        Task<Product> DeleteAsync(int id);
        Task<Product> UpdateAsync(int id, Product entity);
    }
}
