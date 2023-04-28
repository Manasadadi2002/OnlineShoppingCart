using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Repository
{
    public class ProductRepository:IProductRepository
    {
      
        private readonly ShoppingDbContext shoppingDb; 
        public ProductRepository(ShoppingDbContext shoppingDb)
        {
            this.shoppingDb = shoppingDb; 
        }
        public async Task<Product> AddAsync(Product product)
        { 
            await shoppingDb.AddAsync(product); 
            await shoppingDb.SaveChangesAsync();
            return product; 
        }
        public async Task<Product> DeleteAsync(int id)
        {
            var product = await shoppingDb.Product.FirstOrDefaultAsync(x => x.ProductId == id); 
            if (product == null)
            {
                return null;
            }     
            //Delete the region  
            shoppingDb.Product.Remove(product);    
            await shoppingDb.SaveChangesAsync();
            return product;
            
            }     
        public async Task<IEnumerable<Product>> GetAllAsync()    
        {    
            var Product = await shoppingDb.Product.ToListAsync();     
            return Product;       
        }    
        public async Task<Product> GetAsync(int id)    
        {           
            return await shoppingDb.Product.FirstOrDefaultAsync(x => x.ProductId == id);   
        }   
        public async Task<Product> UpdateAsync(int id, Product product)    
        {     
            var update = await shoppingDb.Product.FirstOrDefaultAsync(x => x.ProductId == id);    
            if (update == null)          
            {         
                return null;          
            }       
            update.Category = product.Category;          
            update.ProductName = product.ProductName;    
            update.Price = product.Price;
            update.Description = product.Description;
            update.ProductImage = product.ProductImage;
            await shoppingDb.SaveChangesAsync();   
            return update;    
            
        }

        }
    }
