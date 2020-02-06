using Flenergy.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flenergy.Data.Repository.Interface
{
    public interface IMeterRepository : IRepository<Adm_Meter>
    {
      
        Task<ICollection<Adm_Meter>> GetMetersByEstateId(int id);
     
    }
}
