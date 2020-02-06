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
    public class EstateRepo : IEstateRepository
    {
        private readonly ApplicationDbContext _context;

        public EstateRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Count() => await _context.Estates.CountAsync();


        public async Task<int> DeleteAsync(Estate obj)
        {
            var estate = _context.Estates.Remove(obj);
            var noOfRowAffected = await _context.SaveChangesAsync();
            return noOfRowAffected;
        }

        public async Task<ICollection<Estate>> GetAll() => await _context.Estates.Include(c => c.Customers).Include(c => c.EstateAdmins).ToListAsync();

        public async Task<ICollection<AdmStates>> GetAllStatesAsync() => await _context.AdmStates.ToListAsync();
        

        public async Task<Estate> GetByIdAsync(int Id) => await _context.Estates.FirstOrDefaultAsync(c => c.EstateId == Id);

        public async Task<int> GetCountOfCustomersOfAnEstate(int id)
        {
           var customers = await  _context.Customers.Where(c => c.EstateId == id).CountAsync();
            var Estate = await _context.Estates.FirstOrDefaultAsync(c => c.EstateId == id);
            Estate.NoOfCustomers = customers;
            _context.Estates.Update(Estate);
            await  _context.SaveChangesAsync();
            return customers;

        }

        public async Task<ICollection<Customer>> GetCustomerOfAnEstate(int id) => await _context.Customers.Where(c => c.EstateId == id).ToListAsync();
     

        public async Task<ICollection<LocalGovernment>> GetLgaByStatesName(string id) => await _context.LocalGovernments.Include(c => c.AdmStates).Where(c => c.AdmStates.StateName == id).ToListAsync();

        public async Task<AdmStates> GetStatesById(string id) => await _context.AdmStates.FirstOrDefaultAsync(c => c.StateId == Convert.ToInt32(id));
      

        public async Task<Estate> InsertAsync(Estate obj)
        {
            var estate = await _context.Estates.AddAsync(obj);
            await _context.SaveChangesAsync();
            return estate.Entity;
        }

        public bool IsExist(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsExistEmail(string id)
        {
            var email = await _context.Estates.FirstOrDefaultAsync(c => c.Email == id);
            if (email != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> IsExistPhoneNumber(string id)
        {
            var number = await _context.Estates.FirstOrDefaultAsync(c => c.PhoneNo == id);
            if (number != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Estate> Update(int Id, Estate obj)
        {
            var estate = _context.Estates.Update(obj);
            await _context.SaveChangesAsync();
            return estate.Entity;
        }
    }
}
