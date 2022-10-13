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
    public class CustomerServices : ICustomer
    {
        private readonly ContextDb _contextDb;

        public CustomerServices(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _contextDb.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(Guid? id)
        {
            Customer customerToShow = await _contextDb.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
            return customerToShow;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            await _contextDb.Customers.AddAsync(customer);
            await _contextDb.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> EditCustomer(Customer customer)
        {
            _contextDb.Customers.Update(customer);
            await _contextDb.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteCustomer(Guid id)
        {
            Customer customerToDelete = await _contextDb.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
            _contextDb.Customers.Remove(customerToDelete);
            await _contextDb.SaveChangesAsync();
            return customerToDelete;
        }
    }
}
