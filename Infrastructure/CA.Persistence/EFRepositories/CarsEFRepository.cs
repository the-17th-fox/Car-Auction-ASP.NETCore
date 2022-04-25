using CA.Domain.Entities;
using CA.Domain.GlobalExceptions;
using CA.Domain.Models.Cars;
using CA.Domain.Models.Pages;
using CA.Domain.RepositoryInterfaces;
using CA.Domain.Utilities;
using CA.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Persistence.EFRepositories
{
    public class CarsEFRepository : ICarsRepository
    {
        private readonly AuctionContext _context;
        internal CarsEFRepository(AuctionContext context) => _context = context;

        public async Task<bool> AddAsync(Car entity)
        {
            try
            {
                _context.Add(entity!);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new CreatingFailedException();
            }
        }

        public async Task<bool> DeleteAsync(Car entity)
        {
            try
            {
                _context.Remove(entity!);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new DeletingFailedException();
            }
        }

        public async Task<PagedList<Car>> GetAllAsync(PageSettingsModel settings)
        {
            try
            {
                var query = _context.Cars.AsNoTracking();
                return await PagedList<Car>.ToPagedListAsync(query, settings.SelectedPage, settings.PageSize);
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public async Task<Car?> GetAsNoTracking(int id)
        {
            try
            {
                return await _context.Cars
                    .AsNoTracking()
                    .Where(e => e.Id == id)
                    .Include(e => e.Seller)
                    .Include(e => e.Lots)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public async Task<Car?> GetAsync(int id)
        {
            try
            {
                return await _context.Cars
                    .Where(e => e.Id == id)
                    .Include(e => e.Seller)
                    .Include(e => e.Lots)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public async Task<Car> ChangeGradeAsync(Car car, short grade)
        {
            try
            {
                car.Grade = grade;
                await _context.SaveChangesAsync();
                return car;
            }
            catch (Exception)
            {
                throw new UpdatingFailedException();
            }
        }

        public async Task<Car> ChangeMalfunctionsInfoAsync(Car car, CarMalfunctionsInfoModel parameters)
        {
            try
            {
                car.HasSuspensionMalfunctions = parameters.HasSuspensionMalfunctions;
                car.FaultedElectronicsAmount = parameters.FaultedElectronicsAmount;
                car.StrongScratchesAmount = parameters.StrongScratchesAmount;
                car.SmallScratchesAmount = parameters.SmallScratchesAmount;

                await _context.SaveChangesAsync();
                return car;
            }
            catch (Exception)
            {
                throw new UpdatingFailedException();
            }
        }

        public async Task<Car> ChangeManufacturingInfoAsync(Car car, CarManufacturingInfoModel parameters)
        {
            try
            {
                car.Manufacturer = parameters.Manufacturer;
                car.ManufacturingYear = parameters.ManufacturingYear;
                car.Model = parameters.Model;
                car.VIN = parameters.VIN;
                car.MSRP = parameters.MSRP;

                await _context.SaveChangesAsync();
                return car;
            }
            catch (Exception)
            {
                throw new UpdatingFailedException();
            }
        }

        public async Task<Car> ChangeParametersAsync(Car car, CarParametersModel parameters)
        {
            try
            {
                car.OdometerValue = parameters.OdometerValue;
                car.InternalColor = parameters.InternalColor;
                car.ExternalColor = parameters.ExternalColor;

                await _context.SaveChangesAsync();
                return car;
            }
            catch (Exception)
            {
                throw new UpdatingFailedException();
            }
        }

        public async Task<Car> SetPriceAsync(Car car, decimal price)
        {
            try
            {
                car.StartingPrice = price;

                await _context.SaveChangesAsync();
                return car;
            }
            catch (Exception)
            {
                throw new UpdatingFailedException();
            }
        }
    }
}
