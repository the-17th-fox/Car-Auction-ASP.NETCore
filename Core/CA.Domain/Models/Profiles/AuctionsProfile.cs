using AutoMapper;
using CA.Domain.Entities;
using CA.Domain.Enums;
using CA.Domain.Models.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Profiles
{
    public class AuctionsProfile : Profile
    {
        public AuctionsProfile()
        {
            CreateMap<Auction, AuctionLotsModel>();
            CreateMap<Auction, AuctionParametersModel>().ReverseMap();
            CreateMap<Auction, ShortAuctionModel>();

            CreateMap<Auction, AuctionStatusCodeModel>()
                .ForMember(
                    m => m.StatusMessage,
                    a => a.MapFrom(src =>
                        Enum.GetName(typeof(AuctionStatusCodes), src.StatusCode)));

            CreateMap<Auction, FullAuctionModel>()
                .ForMember(
                    m => m.StatusMessage, 
                    a => a.MapFrom(src => 
                        Enum.GetName(typeof(AuctionStatusCodes), src.StatusCode)));
        }
    }
}
