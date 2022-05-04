﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Transactions
{
    public class ShortTransactionModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public short TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
