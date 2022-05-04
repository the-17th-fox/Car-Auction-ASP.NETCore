using CA.Domain.Entities;
using CA.Domain.Models.Page;
using CA.Domain.Models.Pages;
using CA.Domain.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Abstractions
{
    public interface ITransactionsService : IGenericService<Transaction>
    {
        public Task<AddedTransactionsModel> AddAsync(NewTransactionsModel model);
        public Task<FullTransactionModel> GetAsync(int id);
        public Task<PageModel<ShortTransactionModel>> GetAllAsync(PageSettingsModel settings);
        public Task<PageModel<UserTransactionModel>> GetUserTransactions(int userId, PageSettingsModel settings);
    }
}
