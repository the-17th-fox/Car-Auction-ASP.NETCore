using AutoMapper;
using CA.Domain.Entities;
using CA.Domain.Models.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Profiles
{
    public class BidsProfile : Profile
    {
        public BidsProfile()
        {
            CreateMap<Bid, FullBidModel>();
            CreateMap<Bid, LotBidModel>();
            CreateMap<Bid, UserBidModel>();
        }
    }
}
