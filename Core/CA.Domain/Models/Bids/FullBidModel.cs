using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Bids
{
    public class FullBidModel
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public int UserId { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime SetBidDate { get; set; }
    }
}
