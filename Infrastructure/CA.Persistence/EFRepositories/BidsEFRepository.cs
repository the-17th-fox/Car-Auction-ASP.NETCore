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
    public class BidsEFRepository : GenericEFRepository<Bid>, IBidsRepository
    {
        public BidsEFRepository(AuctionContext context) : base(context) { }

        public async Task<Bid?> GetLargestBid(int lotId)
        {
            try
            {
                return await _table
                    .AsNoTracking()
                    .Where(e => e.LotId == lotId)
                    .OrderByDescending(e => e.BidAmount)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public Task<PagedList<Bid>> GetLotBids(int lotId, PageSettingsModel settings)
        {
            try
            {
                var query = _table.AsNoTracking().Where(e => e.LotId == lotId);
                return PagedList<Bid>.ToPagedListAsync(query, settings.SelectedPage, settings.PageSize);
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public Task<PagedList<Bid>> GetUserBids(int userId, PageSettingsModel settings)
        {
            try
            {
                var query = _table.AsNoTracking().Where(e => e.UserId == userId);
                return PagedList<Bid>.ToPagedListAsync(query, settings.SelectedPage, settings.PageSize);
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }
    }
}
