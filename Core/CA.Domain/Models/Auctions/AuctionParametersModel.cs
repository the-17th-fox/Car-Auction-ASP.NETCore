using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Auctions
{
    public class AuctionParametersModel
    {
        public string Title { get; set; } = String.Empty;
        public DateTime OpenedAt { get; set; }
        public DateTime ClosedAt { get; set; }
    }
}
