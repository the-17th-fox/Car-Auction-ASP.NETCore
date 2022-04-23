using CA.Domain.Entities;
using CA.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.RepositoryInterfaces
{
    public interface IUsersRepository
    {
        public Task<User> ChangePersonalInfo(User user, UserPersonalInfoModel model);
    }
}
