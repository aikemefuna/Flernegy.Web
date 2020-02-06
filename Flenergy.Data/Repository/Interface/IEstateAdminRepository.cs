using Flenergy.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flenergy.Data.Repository.Interface
{
    public interface IEstateAdminRepository : IRepository<EstateAdmin>
    {
        Task<LocalGovernment> GetLgaByNameAsync(string name);
        Task<AdmStates> GetStateByNameAsync(string name);
        Task<ICollection<AdmStates>> GetAllState();
        Task<ICollection<LocalGovernment>> GetAllLga();
    }
}
