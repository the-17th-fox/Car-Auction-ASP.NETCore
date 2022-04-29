using CA.Domain.Entities;
using CA.Domain.GlobalExceptions;
using CA.Domain.Models.Pages;
using CA.Domain.RepositoryInterfaces;
using CA.Domain.Utilities;
using CA.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Persistence.EFRepositories
{
    public class TransactionsEFRepository : GenericEFRepository<Transaction>, ITransactionsRepository
    {
        public TransactionsEFRepository(AuctionContext context) : base(context) { }

        public async Task<List<Transaction>> AddAsync(Transaction firstOperation, Transaction secondOperation)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                await _context.AddAsync(firstOperation!);
                await _context.SaveChangesAsync();

                await _context.AddAsync(secondOperation);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return new List<Transaction>() { firstOperation, secondOperation };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw new CreatingFailedException();
            }
        }

        public async Task<PagedList<Transaction>> GetUserTransactionsAsync(int userId, PageSettingsModel settings)
        {
            try
            {
                var query = _context.Transactions
                    .AsNoTracking()
                    .Where(e => e.UserId == userId);
                return await PagedList<Transaction>.ToPagedListAsync(query, settings.SelectedPage, settings.PageSize);
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }
    }
}
