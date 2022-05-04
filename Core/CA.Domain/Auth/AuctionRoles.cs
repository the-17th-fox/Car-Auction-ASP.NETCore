using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Auth
{
    public class AuctionRoles
    {
        private static int _idCounter = 1;
        public const string DefaultUser = "DefaultUser";
        public const string Administrator = "Administrator";

        private static readonly List<IdentityRole<int>> Roles = new()
        {
            new IdentityRole<int>(DefaultUser) { Id = _idCounter++, NormalizedName = DefaultUser.Normalize() },
            new IdentityRole<int>(Administrator) { Id = _idCounter++, NormalizedName = Administrator.Normalize() }
        };

        public static List<IdentityRole<int>> GetRolesList() => Roles;
    }
}
