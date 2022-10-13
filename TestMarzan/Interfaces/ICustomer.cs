using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMarzan.Models;

namespace TestMarzan.Interfaces
{
    public interface ICustomer
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(Guid? id);
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> EditCustomer(Customer customer);
        Task<Customer> DeleteCustomer(Guid id);
    }
}
