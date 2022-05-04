using AutoMapper;
using CA.Domain.Entities;
using CA.Domain.Models.Page;
using CA.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Profiles
{
    public class PageProfile : Profile
    {
        public PageProfile()
        {
            CreateMap<PagedList<Transaction>, PageModel<Transaction>>()
                .ForMember(m => m.Items, pl => pl.MapFrom(src => src.ToList()));

            CreateMap<PagedList<Auction>, PageModel<Auction>>()
                .ForMember(m => m.Items, pl => pl.MapFrom(src => src.ToList()));

            CreateMap<PagedList<Car>, PageModel<Car>>()
                .ForMember(m => m.Items, pl => pl.MapFrom(src => src.ToList()));

            CreateMap<PagedList<Bid>, PageModel<Bid>>()
                .ForMember(m => m.Items, pl => pl.MapFrom(src => src.ToList()));

            CreateMap<PagedList<Lot>, PageModel<Lot>>()
                .ForMember(m => m.Items, pl => pl.MapFrom(src => src.ToList()));

            CreateMap<PagedList<User>, PageModel<User>>()
                .ForMember(m => m.Items, pl => pl.MapFrom(src => src.ToList()));
        }
    }
}
