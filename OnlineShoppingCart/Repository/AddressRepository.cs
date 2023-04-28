using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Repository
{
    public class AddressRepository:IAddressRepository
    {
        private readonly ShoppingDbContext shoppingDb;
        public AddressRepository(ShoppingDbContext shoppingDb)
        {
            this.shoppingDb = shoppingDb;
        }
        public async Task<Address> AddAsync(Address address)
        {
            await shoppingDb.AddAsync(address);
            await shoppingDb.SaveChangesAsync();
            return address;
        }
        public async Task<Address> DeleteAsync(int id)
        {
            var address = await shoppingDb.Address.FirstOrDefaultAsync(x => x.UserId == id);
            if (address == null)
            {
                return null;
            }
            //Delete the region  
            shoppingDb.Address.Remove(address);
            await shoppingDb.SaveChangesAsync();
            return address;

        }
        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            var address = await shoppingDb.Address.ToListAsync();
            return address;
        }
        public async Task<Address> GetAsync(int id)
        {
            return await shoppingDb.Address.FirstOrDefaultAsync(x => x.UserId == id);
        }
        public async Task<Address> UpdateAsync(int id, Address address)
        {
            var update = await shoppingDb.Address.FirstOrDefaultAsync(x => x.UserId == id);
            if (update == null)
            {
                return null;
            }
            update.UserId = address.UserId;
            update.AddressInfo = address.AddressInfo;
            update.City = address.City;
            update.State = address.State;
            update.Pincode = address.Pincode;
           

            await shoppingDb.SaveChangesAsync();
            return update;

        }
    }
}
