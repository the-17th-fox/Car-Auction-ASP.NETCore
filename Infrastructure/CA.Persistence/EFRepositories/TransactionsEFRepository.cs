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
    public class TransactionsEFRepository : ITransactionsRepository
    {
        private readonly AuctionContext _context;
        public TransactionsEFRepository(AuctionContext context) => _context = context;

        public async Task<bool> AddAsync(Transaction entity)
        {
            try
            {
                _context.Add(entity!);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new CreatingFailedException();
            }
        }

        public async Task<bool> DeleteAsync(Transaction entity)
        {
            try
            {
                _context.Remove(entity!);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new DeletingFailedException();
            }
        }

        public async Task<PagedList<Transaction>> GetAllAsync(PageSettingsModel settings)
        {
            try
            {
                var query = _context.Transactions.AsNoTracking();
                return await PagedList<Transaction>.ToPagedListAsync(query, settings.SelectedPage, settings.PageSize);
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public async Task<Transaction?> GetAsNoTracking(int id)
        {
            try
            {
                return await _context.Transactions
                    .AsNoTracking()
                    .Where(e => e.Id == id)
                    .Include(e => e.User.Id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public async Task<Transaction?> GetAsync(int id)
        {
            try
            {
                return await _context.Transactions
                    .Where(e => e.Id == id)
                    .Include(e => e.User.Id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }
    }
}
