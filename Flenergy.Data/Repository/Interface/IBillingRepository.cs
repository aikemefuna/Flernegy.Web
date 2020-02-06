using Flenergy.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flenergy.Data.Repository.Interface
{
    public interface IBillingRepository : IRepository<BillingCategory>
    {
        Task<int> GetCountOfCustomersForACategory(int id);
        Task<ICollection<BillingCategory>> GetCategoriesbyEstateId(int id);
    }
}
