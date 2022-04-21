using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public List<Transaction> Transactions { get; set; } = new();
        public List<Bid> Bids { get; set; } = new();
        public List<Car> Car { get; set; } = new();
    }
}
