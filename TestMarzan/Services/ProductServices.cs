using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMarzan.Data;
using TestMarzan.Interfaces;
using TestMarzan.Models;

namespace TestMarzan.Services
{
    public class ProductServices : IProduct
    {
        private readonly ContextDb _contextDb;

        public ProductServices(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _contextDb.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(Guid? id)
        {
            Product productToShow = await _contextDb.Products.FirstOrDefaultAsync(product => product.Id == id);
            return productToShow;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            await _contextDb.Products.AddAsync(product);
            await _contextDb.SaveChangesAsync();
            return product;
        } 

        public async Task<Product> EditProduct(Product product)
        {
            _contextDb.Products.Update(product);
            await _contextDb.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProduct(Guid id)
        {
            Product productToDelete =await _contextDb.Products.FirstOrDefaultAsync(product => product.Id == id);
            _contextDb.Products.Remove(productToDelete);
            await _contextDb.SaveChangesAsync();
            return productToDelete;
        }
    }
}
