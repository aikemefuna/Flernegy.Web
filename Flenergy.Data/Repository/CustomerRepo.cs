using Flenergy.Data.DbContexts;
using Flenergy.Data.Models;
using Flenergy.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flenergy.Data.Repository
{
    public class CustomerRepo : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Count() => await _context.Customers.CountAsync();
       

        public async Task<int> DeleteAsync(Customer obj)
        {
            var customer = _context.Customers.Remove(obj);
            var noOfRowAffected = await _context.SaveChangesAsync();
            return noOfRowAffected;
        }

        public async Task<ICollection<Customer>> GetAll() => await _context.Customers.Include(c => c.BillingCategory).Include(c => c.Estate).ToListAsync();
        

        public async Task<Customer> GetByIdAsync(int Id) => await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == Id);

     

        public async Task<int> GetCountOfMetersByCustomer(int id)
        {
            var meters = await _context.Adm_Meter.Where(c => c.CustomerId == id).CountAsync();
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            customer.NoOfMeter = meters;
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return meters;

        }
        public async Task<Customer> InsertAsync(Customer obj)
        {
            var customer = await _context.Customers.AddAsync(obj);
            await _context.SaveChangesAsync();
            return customer.Entity;
        }

        public bool IsExist(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> Update(int Id, Customer obj)
        {
            var customer = _context.Customers.Update(obj);
            await _context.SaveChangesAsync();
            return customer.Entity;
        }
    }
}
