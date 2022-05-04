using CA.Domain.Models.Lots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Auctions
{
    public class AuctionLotsModel
    {
        public int Id { get; set; }
        public List<ShortLotModel> Lots { get; set; } = new();
    }
}
