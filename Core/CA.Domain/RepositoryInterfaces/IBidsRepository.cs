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
    public interface IBidsRepository : IGenericRepository<Bid> 
    {
        public Task<PagedList<Bid>> GetLotBids(int lotId, PageSettingsModel settings);
        public Task<PagedList<Bid>> GetUserBids(int userId, PageSettingsModel settings);
        public Task<Bid?> GetLargestBid(int lotId);
        
    }
}
