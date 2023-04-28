using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly ShoppingDbContext shoppingDb;
        public OrderRepository(ShoppingDbContext shoppingDb)
        {
            this.shoppingDb = shoppingDb;
        }
        public async Task<Order> AddAsync(Order order)
        {
            await shoppingDb.AddAsync(order);
            await shoppingDb.SaveChangesAsync();
            return order;
        }
        public async Task<Order> DeleteAsync(int id)
        {
            var order = await shoppingDb.Order.FirstOrDefaultAsync(x => x.CartId == id);
            if (order == null)
            {
                return null;
            }
            //Delete the region  
            shoppingDb.Order.Remove(order);
            await shoppingDb.SaveChangesAsync();
            return order;

        }
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var order = await shoppingDb.Order.ToListAsync();
            return order;
        }
        public async Task<Order> GetAsync(int id)
        {
            return await shoppingDb.Order.FirstOrDefaultAsync(x => x.CartId == id);
        }
        public async Task<Order> UpdateAsync(int id, Order order)
        {
            var update = await shoppingDb.Order.FirstOrDefaultAsync(x => x.CartId == id);
            if (update == null)
            {
                return null;
            }
            update.UserId = order.UserId;
            update.ProductId = order.ProductId;
            update.ProductName = order.ProductName;
            update.ProductImage = order.ProductImage;
            update.Quantity = order.Quantity;
            update.Price = order.Price;

            await shoppingDb.SaveChangesAsync();
            return update;

        }
    }
}
