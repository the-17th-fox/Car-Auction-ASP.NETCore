using CA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.RepositoryInterfaces
{
    public interface IAuctionsRepository : IBasicRepository<Auction>
    {
        public Task<bool> ChangeStatusAsync(int auctionId, short statusCode);
    }
}
