using AutoMapper;
using CA.Domain.Entities;
using CA.Domain.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Profiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            CreateMap<Car, CarPriceModel>();
            CreateMap<Car, ShortCarModel>();
            CreateMap<Car, UserCarModel>();
            CreateMap<Car, FullCarModel>();
            CreateMap<Car, CarMalfunctionsInfoModel>().ReverseMap();
            CreateMap<Car, CarManufacturingInfoModel>().ReverseMap();
            CreateMap<Car, CarParametersModel>().ReverseMap();
        }
    }
}
