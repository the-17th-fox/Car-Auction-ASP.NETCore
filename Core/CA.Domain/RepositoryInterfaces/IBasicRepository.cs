using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.RepositoryInterfaces
{
    public interface IBasicRepository<T>
    {
        public Task<bool> AddAsync(T entity);
        public Task<bool> DeleteAsync(int id);
        public Task<T> GetByIdAsync(int id);
        public Task<List<T>> GetAllAsync();
    }
}
