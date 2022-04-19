using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Entities
{
    public class Transaction : BasicEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public short TransactionType { get; set; } // TransactionTypes enum
        public string? Message { get; set; }

        [Display(Name = "Money")]
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; } = DateTime.UtcNow;
    }
}
