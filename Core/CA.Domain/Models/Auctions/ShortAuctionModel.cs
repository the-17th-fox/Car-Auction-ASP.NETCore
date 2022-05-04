using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Auctions
{
    public class ShortAuctionModel
    {
        public int Id { get; set; }
        public DateTime OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public int StatusCode { get; set; } // Auction status codes
    }
}
