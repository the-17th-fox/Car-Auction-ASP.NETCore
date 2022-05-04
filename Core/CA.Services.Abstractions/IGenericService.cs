using CA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Abstractions
{
    public interface IGenericService<T> where T : BasicEntity
    {
        /// <summary>Returns an instance from the repository by it's id. For in-service use only.</summary>
        /// <param name="id"></param>
        /// <returns>NotFoundException if was not found, or TEntity if found.</returns>
        public Task<T> ValidateAsync(int id);

        /// <summary>Returns an instance from the repository by it's id without tracking. For in-service use only.</summary>
        /// <param name="id"></param>
        /// <returns>NotFoundException if was not found, or TEntity without context tracking if found.</returns>
        public Task<T> ValidateAsNoTrackingAsync(int id);
    }
}
