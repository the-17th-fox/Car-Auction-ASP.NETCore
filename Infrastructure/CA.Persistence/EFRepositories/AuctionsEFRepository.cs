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
    public class AuctionsEFRepository : GenericEFRepository<Auction>
    {
        public AuctionsEFRepository(AuctionContext context) : base(context) { }
    }
}
