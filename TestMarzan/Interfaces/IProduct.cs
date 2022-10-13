using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMarzan.Models;

namespace TestMarzan.Interfaces
{
    public interface IProduct
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(Guid? id);
        Task<Product> CreateProduct(Product product);
        Task<Product> EditProduct(Product product);
        Task<Product> DeleteProduct(Guid id);
    }
}
