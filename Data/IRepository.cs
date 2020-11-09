using Project1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Project1.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> ListAllAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<int> CountAsync();
    }
}
