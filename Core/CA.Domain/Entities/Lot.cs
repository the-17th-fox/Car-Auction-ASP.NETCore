using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Entities
{
    public class Lot : BasicEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int AuctionId { get; set; }
        public Auction? Auction { get; set; }

        public int LastBidId { get; set; }
        public LotBid? LastBid { get; set; }

        public decimal? StartingPrice { get { return Car.Price; } }
        public short StatusCode { get; set; } // Lot status codes
    }
}
