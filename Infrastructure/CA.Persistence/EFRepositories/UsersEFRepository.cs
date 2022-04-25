using CA.Domain.Entities;
using CA.Domain.GlobalExceptions;
using CA.Domain.Models.Users;
using CA.Domain.RepositoryInterfaces;
using CA.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Persistence.EFRepositories
{
    public class UsersEFRepository : IUsersRepository
    {
        private readonly AuctionContext _context;
        public UsersEFRepository(AuctionContext context) => _context = context;

        public async Task<User> ChangePersonalInfo(User user, UserPersonalInfoModel model)
        {
            try
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception)
            {
                throw new UpdatingFailedException();
            }
        }
    }
}
