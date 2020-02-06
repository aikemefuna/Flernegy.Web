using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flenergy.Data.Repository.Interface
{
    public interface IRepository<T>
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetByIdAsync(int Id);
        Task<T> InsertAsync(T obj);
        Task<T> Update(int Id, T obj);
        Task<int> DeleteAsync(T obj);
        Task<int> Count();
        bool IsExist(int Id);
    }
}
