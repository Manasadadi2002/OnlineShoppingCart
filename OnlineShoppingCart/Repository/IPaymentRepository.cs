using OnlineShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Repository
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment> GetAsync(int id);
        Task<Payment> AddAsync(Payment entity);
        Task<Payment> DeleteAsync(int id);
        Task<Payment> UpdateAsync(int id, Payment entity);
    }
}
