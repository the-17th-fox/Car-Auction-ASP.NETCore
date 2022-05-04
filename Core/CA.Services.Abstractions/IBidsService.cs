using CA.Domain.Entities;
using CA.Domain.Models.Bids;
using CA.Domain.Models.Page;
using CA.Domain.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Abstractions
{
    public interface IBidsService : IGenericService<Bid>
    {
        public Task<FullBidModel> AddAsync(int userId, NewBidModel model);
        public Task<FullBidModel> GetAsync(int id);
        public Task<PageModel<FullBidModel>> GetAllAsync(PageSettingsModel settings);
        public Task<PageModel<LotBidModel>> GetLotBidsAsync(int lotId, PageSettingsModel settings);
        public Task<PageModel<UserBidModel>> GetUserBidsAsync(int userId, PageSettingsModel settings);

    }
}
