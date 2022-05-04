using CA.Domain.Entities;
using CA.Domain.Models.Auctions;
using CA.Domain.Models.Page;
using CA.Domain.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Abstractions
{
    public interface IAuctionsService : IGenericService<Auction>
    {
        public Task<FullAuctionModel> AddAsync(AuctionParametersModel model);

        public Task<FullAuctionModel> GetAsync(int id);
        public Task<PageModel<ShortAuctionModel>> GetAllAsync(PageSettingsModel settings);

        public Task<FullAuctionModel> UpdateParametersAsync(int id, AuctionParametersModel model);
        public Task<AuctionStatusCodeModel> UpdateStatusCodeAsync(int id, short statusCode);
        public Task<AuctionLotsModel> AssignLotAsync(int auctionId, int lotId);
        public Task<AuctionLotsModel> RemoveLotAsync(int auctionId, int lotId);
    }
}
