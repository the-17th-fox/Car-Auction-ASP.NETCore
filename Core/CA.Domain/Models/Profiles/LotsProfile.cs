using AutoMapper;
using CA.Domain.Entities;
using CA.Domain.Enums;
using CA.Domain.Models.Lots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Profiles
{
    public class LotsProfile : Profile
    {
        public LotsProfile()
        {
            CreateMap<Lot, FullLotModel>();
            CreateMap<Lot, ShortLotModel>();

            CreateMap<Lot, LotStatusCodeModel>()
                .ForMember(
                    m => m.StatusMessage,
                    a => a.MapFrom(src =>
                        Enum.GetName(typeof(LotStatusCodes), src.StatusCode)));
        }
    }
}
