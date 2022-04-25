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
        [ForeignKey("CarId")]
        public Car Car { get; set; } = null!;
        [ForeignKey("AuctionId")]
        public Auction? Auction { get; set; }
        public List<Bid> Bids { get; set; } = new();

        [Column(TypeName = "decimal(9,2)")]
        public decimal? SoldFor { get; set; }
        public short StatusCode { get; set; } // Lot status codes

        [NotMapped]
        public decimal? StartingPrice { get { return Car.StartingPrice; } }
    }
}
