using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Entities
{
    public class LotBid : BasicEntity
    {
        public int LotId { get; set; }
        public Lot Lot { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public decimal BidAmount { get; set; }
        public DateTime SetBidDate { get; } = DateTime.UtcNow;
    }
}
