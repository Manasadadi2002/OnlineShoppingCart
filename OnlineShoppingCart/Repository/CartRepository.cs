using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Repository
{
    public class CartRepository:ICartRepository
    {
        private readonly ShoppingDbContext shoppingDb;
        public CartRepository(ShoppingDbContext shoppingDb)
        {
            this.shoppingDb = shoppingDb;
        }
        public async Task<Cart> AddAsync(Cart cart)
        {
            await shoppingDb.AddAsync(cart);
            await shoppingDb.SaveChangesAsync();
            return cart;
        }
        public async Task<Cart> DeleteAsync(int id)
        {
            var cart = await shoppingDb.Cart.FirstOrDefaultAsync(x => x.CartId == id);
            if (cart == null)
            {
                return null;
            }
            //Delete the region  
            shoppingDb.Cart.Remove(cart);
            await shoppingDb.SaveChangesAsync();
            return cart;

        }
        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            var cart = await shoppingDb.Cart.ToListAsync();
            return cart;
        }
        public async Task<Cart> GetAsync(int Cartid)
        {
            return await shoppingDb.Cart.FirstOrDefaultAsync(x => x.CartId == Cartid);
        }
        public async Task<Cart> UpdateAsync(int Cartid, Cart cart)
        {
            var update = await shoppingDb.Cart.FirstOrDefaultAsync(x => x.CartId == Cartid);
            if (update == null)
            {
                return null;
            }
            update.UserId = cart.UserId;
            update.ProductId = cart.ProductId;
            update.ProductName = cart.ProductName;
            update.ProductImage = cart.ProductImage;
            update.Quantity = cart.Quantity;
            update.Price = cart.Price;
           
            await shoppingDb.SaveChangesAsync();
            return update;

        }

    }
}
