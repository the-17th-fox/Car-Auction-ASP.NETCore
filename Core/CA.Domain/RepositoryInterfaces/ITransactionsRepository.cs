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
    public interface ITransactionsRepository : IGenericRepository<Transaction>
    {
        public Task<List<Transaction>> AddAsync(Transaction firstOperation, Transaction secondOperation);
        public Task<PagedList<Transaction>> GetUserTransactionsAsync(int userId, PageSettingsModel settings);
    }
}
