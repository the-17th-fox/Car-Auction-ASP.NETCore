using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Entities
{
    public class Bid : BasicEntity
    {
        public int LotId { get; set; }
        [ForeignKey("LotId")]
        public Lot Lot { get; set; } = null!;

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        [Column(TypeName = "decimal(9,2)")]
        public decimal BidAmount { get; set; }
        public DateTime SetBidDate { get; private set; } = DateTime.UtcNow;
    }
}
