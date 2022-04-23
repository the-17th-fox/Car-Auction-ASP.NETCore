using CA.Domain.Entities;
using CA.Domain.Models.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.RepositoryInterfaces
{
    public interface IAuctionsRepository : IBasicRepository<Auction>
    {
        public Task<Auction> ChangeStatusAsync(Auction auction, short statusCode);
        public Task<Auction> ChangeParametersAsync(Auction auction, AuctionParametersModel parameters);
        public Task<Auction> AssignLotAsync(Auction auction, Lot lot);
        public Task<Auction> RemoveLotAsync(Auction auction, Lot lot);
    }
}
