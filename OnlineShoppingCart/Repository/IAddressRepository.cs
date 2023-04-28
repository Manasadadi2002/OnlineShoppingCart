using OnlineShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Repository
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAsync();
        Task<Address> GetAsync(int id);
        Task<Address> AddAsync(Address entity);
        Task<Address> DeleteAsync(int id);
        Task<Address> UpdateAsync(int id, Address entity);
    }
}
