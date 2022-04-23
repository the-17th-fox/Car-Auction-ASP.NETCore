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
        public Task<Car> ChangeParametersAsync(Car car, CarParametersModel parameters);
        public Task<Car> ChangeManufacturingInfoAsync(Car car, CarManufacturingInfoModel parameters);
        public Task<Car> ChangeMalfunctionsInfoAsync(Car car, CarMalfunctionsInfoModel parameters);

        public Task<Car> AssignLotAsync(Car car);
        public Task<Car> ChangeGradeAsync(Car car, short grade);
        public Task<Car> SetPriceAsync(Car car, decimal price);
    }
}
