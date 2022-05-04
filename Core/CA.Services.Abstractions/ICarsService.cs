using CA.Domain.Entities;
using CA.Domain.Models.Cars;
using CA.Domain.Models.Page;
using CA.Domain.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Abstractions
{
    public interface ICarsService : IGenericService<Car>
    {
        public Task<FullCarModel> AddAsync(int userId, NewCarModel model);

        public Task<FullCarModel> GetAsync(int id);
        public Task<PageModel<ShortCarModel>> GetAllAsync(PageSettingsModel settings);
        public Task<PageModel<UserCarModel>> GetUserCarsAsync(int userId, PageSettingsModel settings);

        public Task<CarPriceModel> CalculatePriceAsync(int id);
        public Task<CarMalfunctionsInfoModel> UpdateMalfunctionsAsync(int id, CarMalfunctionsInfoModel model);
        public Task<CarManufacturingInfoModel> UpdateManufacturingInfoAsync(int id, CarManufacturingInfoModel model);
        public Task<CarParametersModel> UpdateParametersAsync(int id, CarParametersModel model);
    }
}
