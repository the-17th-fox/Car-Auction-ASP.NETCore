using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Entities
{
    public class Transaction : BasicEntity
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        public short TransactionType { get; set; } // TransactionTypes enum
        public string? Message { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; private set; } = DateTime.UtcNow;
    }
}
