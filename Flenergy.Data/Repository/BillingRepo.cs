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
    public class BillingRepo : IBillingRepository
    {
        private readonly ApplicationDbContext _context;

        public BillingRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Count() => await _context.BillingCategory.CountAsync();


        public async Task<int> DeleteAsync(BillingCategory obj)
        {
            var cat = _context.BillingCategory.Remove(obj);
            var noOfRowAffected = await _context.SaveChangesAsync();
            return noOfRowAffected;
        }

        public async Task<ICollection<BillingCategory>> GetAll() => await _context.BillingCategory.ToListAsync();


        public async Task<BillingCategory> GetByIdAsync(int Id) => await _context.BillingCategory.FirstOrDefaultAsync(c => c.BillingCategoryId == Id);

        public async Task<ICollection<BillingCategory>> GetCategoriesbyEstateId(int id) => await _context.BillingCategory.Where(c => c.EstateId == id).ToListAsync();


        public  async Task<int> GetCountOfCustomersForACategory(int id)
        {
            var customers = await _context.Customers.Where(c => c.BillingCategoryId == id).CountAsync();
            var category = await _context.BillingCategory.FirstOrDefaultAsync(c => c.BillingCategoryId == id);
            category.NoOfCustomers = customers;
            _context.BillingCategory.Update(category);
            await _context.SaveChangesAsync();
            return customers;
        }

        public async Task<BillingCategory> InsertAsync(BillingCategory obj)
        {
            var cat = await _context.BillingCategory.AddAsync(obj);
            await _context.SaveChangesAsync();
            return cat.Entity;
        }

        public bool IsExist(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<BillingCategory> Update(int Id, BillingCategory obj)
        {
            var cat = _context.BillingCategory.Update(obj);
            await _context.SaveChangesAsync();
            return cat.Entity;
        }
    }
}
