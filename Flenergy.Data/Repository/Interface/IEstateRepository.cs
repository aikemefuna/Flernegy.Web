using Flenergy.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flenergy.Data.Repository.Interface
{
    public interface IEstateRepository : IRepository<Estate>
    {
        Task<int> GetCountOfCustomersOfAnEstate(int id);
        Task<ICollection<Customer>> GetCustomerOfAnEstate(int id);
        Task<bool> IsExistEmail(string id);
        Task<bool> IsExistPhoneNumber(string id);
        Task<ICollection<AdmStates>> GetAllStatesAsync();
        Task<ICollection<LocalGovernment>> GetLgaByStatesName(string name);
        Task<AdmStates> GetStatesById(string id);
    }
}
