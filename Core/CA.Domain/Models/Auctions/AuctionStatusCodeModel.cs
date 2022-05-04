﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Auctions
{
    public class AuctionStatusCodeModel
    {
        public int Id { get; set; }
        public short StatusCode { get; set; }
        public string StatusMessage { get; set; } = null!;
    }
}