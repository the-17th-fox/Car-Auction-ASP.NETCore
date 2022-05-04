using CA.Domain.Models.Pages;
using CA.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.RepositoryInterfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> AddAsync(T entity);
        public Task<T> DeleteAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T?> GetAsync(int id);
        public Task<T?> GetAsNoTrackingAsync(int id);
        public Task<PagedList<T>> GetAllAsync(PageSettingsModel settings);
    }
}
