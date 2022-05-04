using CA.Domain.Models.Lots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Auctions
{
    public class FullAuctionModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public List<ShortLotModel> Lots { get; set; } = new();
        public DateTime OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public short StatusCode { get; set; } // Auction status codes
        public string StatusMessage { get; set; } = null!;
    }
}
