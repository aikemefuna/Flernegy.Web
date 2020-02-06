
using Flenergy.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flenergy.Data.Repository.Interface
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<int> GetCountOfMetersByCustomer(int id);
    }
}
