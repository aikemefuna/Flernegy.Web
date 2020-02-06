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
    public class ServiceChargeRepo : IServiceChargeRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceChargeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Count() => await _context.Adm_ServiceCharge.CountAsync();


        public async Task<int> DeleteAsync(Adm_ServiceCharge obj)
        {
            var charge = _context.Adm_ServiceCharge.Remove(obj);
            var noOfRowAffected = await _context.SaveChangesAsync();
            return noOfRowAffected;
        }

        public async Task<ICollection<Adm_ServiceCharge>> GetAll() => await _context.Adm_ServiceCharge.ToListAsync();


        public async Task<Adm_ServiceCharge> GetByIdAsync(int Id) => await _context.Adm_ServiceCharge.FirstOrDefaultAsync(c => c.Adm_ServiceChargeId == Id);


        public async Task<Adm_ServiceCharge> InsertAsync(Adm_ServiceCharge obj)
        {
            var charge = await _context.Adm_ServiceCharge.AddAsync(obj);
            await _context.SaveChangesAsync();
            return charge.Entity;
        }

        public bool IsExist(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Adm_ServiceCharge> Update(int Id, Adm_ServiceCharge obj)
        {
            var charge = _context.Adm_ServiceCharge.Update(obj);
            await _context.SaveChangesAsync();
            return charge.Entity;
        }
    }
}
