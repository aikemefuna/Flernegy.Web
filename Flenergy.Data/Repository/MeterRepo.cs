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
    public class MeterRepo : IMeterRepository
    {
        private readonly ApplicationDbContext _context;

        public MeterRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Count() => await _context.Adm_Meter.CountAsync();
       

        public async Task<int> DeleteAsync(Adm_Meter obj)
        {
            var meter =  _context.Adm_Meter.Remove(obj);
           var noOfRowAffected = await _context.SaveChangesAsync();
            return noOfRowAffected;
        }

        public async Task<ICollection<Adm_Meter>> GetAll() => await _context.Adm_Meter.Include(c => c.Estate).ToListAsync();


       

        public async Task<Adm_Meter> GetByIdAsync(int Id) => await _context.Adm_Meter.FirstOrDefaultAsync(c => c.Adm_MeterId == Id);
       

        public async Task<Adm_Meter> InsertAsync(Adm_Meter obj)
        {
            var meter = await _context.Adm_Meter.AddAsync(obj);
            await _context.SaveChangesAsync();
            return meter.Entity;
        }

        public bool IsExist(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Adm_Meter> Update(int Id, Adm_Meter obj)
        {
            var meter =  _context.Adm_Meter.Update(obj);
            await _context.SaveChangesAsync();
            return meter.Entity;
        }

        public async Task<ICollection<Adm_Meter>> GetMetersByEstateId(int id) => await _context.Adm_Meter.Where(c => c.EstateId == id).ToListAsync();

       
    }
}
