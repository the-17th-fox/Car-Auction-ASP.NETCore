using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Auth
{
    public class TokenConfiguration
    {
        public const string Issuer = "CarsAuction";
        public const string Audience = "CarsAuctionClient";
        public const int LifetimeInMinutes = 720;
        private const string EncodingKey = "qMErZpo133wdFEzAAD1d129bGb1PRF14fOxzz";
        public static SymmetricSecurityKey GetKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(EncodingKey));
        }
    }
}
