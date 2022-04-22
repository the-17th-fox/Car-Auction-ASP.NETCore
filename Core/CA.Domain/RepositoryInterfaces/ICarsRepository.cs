using CA.Domain.Entities;
using CA.Domain.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.RepositoryInterfaces
{
    public interface ICarsRepository : IBasicRepository<Car>
    {
        public Task<Car> ChangeParametersAsync(int id, CarParametersModel parameters);
        public Task<Car> ChangeManufacturingInfoAsync(int id, CarManufacturingInfoModel parameters);
        public Task<Car> ChangeMalfunctionsInfoAsync(int id, CarMalfunctionsInfoModel parameters);
    }
}
