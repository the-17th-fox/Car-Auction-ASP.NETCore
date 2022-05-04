using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Lots
{
    public class ShortLotModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int AuctionId { get; set; }
        public short StatusCode { get; set; } // Lot status codes
    }
}
