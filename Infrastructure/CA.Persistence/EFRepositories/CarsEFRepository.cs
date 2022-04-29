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
    public class CarsEFRepository : GenericEFRepository<Car>, ICarsRepository
    {
        public CarsEFRepository(AuctionContext context) : base(context) { }

        public Task<PagedList<Car>> GetUserCarsAsync(int userId, PageSettingsModel settings)
        {
            try
            {
                var query = _table.AsNoTracking().Where(e => e.SellerId == userId);
                return PagedList<Car>.ToPagedListAsync(query, settings.SelectedPage, settings.PageSize);
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }
    }
}
