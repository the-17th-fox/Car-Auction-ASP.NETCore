using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Transactions
{
    public class AddedTransactionsModel
    {
        public int FirstTransactionId { get; set; }
        public int IncomeTargetId { get; set; } // UserId
        
        public int SecondTransactionId { get; set; }
        public int ExpeditureTargetId { get; set; } // UserId
        
        public string Message { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
