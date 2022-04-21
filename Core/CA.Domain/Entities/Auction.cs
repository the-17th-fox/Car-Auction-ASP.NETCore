using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Entities
{
    public class Auction : BasicEntity
    {
        public string Title { get; set; } = String.Empty;
        public List<Lot> Lots { get; set; } = new();
        public DateTime OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public int StatusCode { get; set; } // Auction status codes
    }
}
