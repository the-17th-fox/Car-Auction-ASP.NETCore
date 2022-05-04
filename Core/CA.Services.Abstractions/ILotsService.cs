using CA.Domain.Entities;
using CA.Domain.Models.Lots;
using CA.Domain.Models.Page;
using CA.Domain.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Services.Abstractions
{
    public interface ILotsService : IGenericService<Lot>
    {
        public Task<FullLotModel> AddAsync(NewLotModel model);
        public Task<FullLotModel> GetAsync(int id);
        public Task<PageModel<ShortLotModel>> GetAllAsync(PageSettingsModel settings);
        public Task<LotStatusCodeModel> UpdateStatusCodeAsync(int id, short statusCode);
        public Task<FullLotModel> SetSoldAsync(int id);
    }
}
