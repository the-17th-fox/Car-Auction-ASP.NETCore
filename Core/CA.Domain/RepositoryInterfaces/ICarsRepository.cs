using CA.Domain.Entities;
using CA.Domain.Models.Pages;
using CA.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.RepositoryInterfaces
{
    public interface ICarsRepository : IGenericRepository<Car>
    {
        public Task<PagedList<Car>> GetUserCarsAsync(int userId, PageSettingsModel settings); 
    }
}
