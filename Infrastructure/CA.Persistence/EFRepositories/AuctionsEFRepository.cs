using CA.Domain.Entities;
using CA.Domain.GlobalExceptions;
using CA.Domain.Models.Auctions;
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
    public class AuctionsEFRepository : IGenericRepository<Auction>
    {
        private readonly AuctionContext _context;
        public AuctionsEFRepository(AuctionContext context) => _context = context;

        public async Task<Auction> AddAsync(Auction entity)
        {
            try
            {
                _context.Add(entity!);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw new CreatingFailedException();
            }
        }

        public async Task<Auction> DeleteAsync(Auction entity)
        {
            try
            {
                _context.Remove(entity!);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw new DeletingFailedException();
            }
        }

        public async Task<PagedList<Auction>> GetAllAsync(PageSettingsModel settings)
        {
            try
            {
                var query = _context.Auctions.AsNoTracking();
                return await PagedList<Auction>.ToPagedListAsync(query, settings.SelectedPage, settings.PageSize);
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public async Task<Auction?> GetAsNoTracking(int id)
        {
            try
            {
                return await _context.Auctions
                    .AsNoTracking()
                    .Where(e => e.Id == id)
                    .Include(e => e.Lots)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public async Task<Auction?> GetAsync(int id)
        {
            try
            {
                return await _context.Auctions
                    .Where(e => e.Id == id)
                    .Include(e => e.Lots)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public async Task<Auction> UpdateAsync(Auction auction)
        {
            try
            {
                await _context.SaveChangesAsync();
                return auction;
            }
            catch (Exception)
            {
                throw new UpdatingFailedException();
            }
        }
    }
}
