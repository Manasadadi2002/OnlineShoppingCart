using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Repository
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly ShoppingDbContext shoppingDb;
        public PaymentRepository(ShoppingDbContext shoppingDb)
        {
            this.shoppingDb = shoppingDb;
        }
        public async Task<Payment> AddAsync(Payment payment)
        {
            await shoppingDb.AddAsync(payment);
            await shoppingDb.SaveChangesAsync();
            return payment;
        }
        public async Task<Payment> DeleteAsync(int id)
        {
            var payment = await shoppingDb.Payment.FirstOrDefaultAsync(x => x.TransactionId == id);
            if (payment == null)
            {
                return null;
            }
            //Delete the region  
            shoppingDb.Payment.Remove(payment);
            await shoppingDb.SaveChangesAsync();
            return payment;

        }
        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            var payment = await shoppingDb.Payment.ToListAsync();
            return payment;
        }
        public async Task<Payment> GetAsync(int id)
        {
            return await shoppingDb.Payment.FirstOrDefaultAsync(x => x.TransactionId == id);
        }
        public async Task<Payment> UpdateAsync(int id, Payment payment)
        {
            var update = await shoppingDb.Payment.FirstOrDefaultAsync(x => x.TransactionId == id);
            if (update == null)
            {
                return null;
            }
            update.TransactionAmount = payment.TransactionAmount;
            update.UserId = payment.UserId;
            update.OrderId = payment.OrderId;
            update.Tstatus = payment.Tstatus;
            update.Mode = payment.Mode;
            update.Code = payment.Code;


            await shoppingDb.SaveChangesAsync();
            return update;

        }
    }
}
