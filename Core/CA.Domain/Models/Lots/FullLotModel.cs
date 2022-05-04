﻿using CA.Domain.Models.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Lots
{
    public class FullLotModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int AuctionId { get; set; }
        public List<FullBidModel> Bids { get; set; } = new();
        public decimal? SoldFor { get; set; }
        public short StatusCode { get; set; } // Lot status codes
        public decimal StartingPrice { get; set; } // Should be mapped manually
    }
}