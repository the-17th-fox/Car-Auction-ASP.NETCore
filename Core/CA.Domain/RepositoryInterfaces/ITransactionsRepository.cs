using CA.Domain.Entities;
using CA.Domain.Models.Pages;
using CA.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.RepositoryInterfaces
{
    public interface ITransactionsRepository
    {
        public Task<IEnumerable<Transaction>> AddAsync(Transaction firstOperation, Transaction secondOperation);
        public Task<Transaction?> GetAsNoTracking(int id);
        public Task<PagedList<Transaction>> GetAllAsync(PageSettingsModel settings);
    }
}
