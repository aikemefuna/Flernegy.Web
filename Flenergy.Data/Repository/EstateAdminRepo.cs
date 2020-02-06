using Flenergy.Data.DbContexts;
using Flenergy.Data.Models;
using Flenergy.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flenergy.Data.Repository
{
    public class EstateAdminRepo : IEstateAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public EstateAdminRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Count() => await _context.EstateAdmins.CountAsync();


        public async Task<int> DeleteAsync(EstateAdmin obj)
        {
            var est = _context.EstateAdmins.Remove(obj);
            var noOfRowAffected = await _context.SaveChangesAsync();
            return noOfRowAffected;
        }

        public async Task<ICollection<EstateAdmin>> GetAll() => await _context.EstateAdmins.Include(c => c.Estate).ToListAsync();
        public async Task<ICollection<AdmStates>> GetAllState() => await _context.AdmStates.ToListAsync();
        public async Task<ICollection<LocalGovernment>> GetAllLga() => await _context.LocalGovernments.Include(c => c.AdmStates).ToListAsync();


        public async Task<EstateAdmin> GetByIdAsync(int Id) => await _context.EstateAdmins.FirstOrDefaultAsync(c => c.EstateAdminId == Id);
        public async Task<LocalGovernment> GetLgaByNameAsync(string name) => await _context.LocalGovernments.FirstOrDefaultAsync(c => c.LocalGovernmentName == name);
        public async Task<AdmStates> GetStateByNameAsync(string name) => await _context.AdmStates.FirstOrDefaultAsync(c => c.StateName == name);

       
        public async Task<EstateAdmin> InsertAsync(EstateAdmin obj)
        {
            var est = await _context.EstateAdmins.AddAsync(obj);
            await _context.SaveChangesAsync();
            return est.Entity;
        }

        public bool IsExist(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<EstateAdmin> Update(int Id, EstateAdmin obj)
        {
            var est = _context.EstateAdmins.Update(obj);
            await _context.SaveChangesAsync();
            return est.Entity;
        }
    }
}
