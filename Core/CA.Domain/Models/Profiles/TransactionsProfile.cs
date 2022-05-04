using AutoMapper;
using CA.Domain.Entities;
using CA.Domain.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Profiles
{
    public class TransactionsProfile : Profile
    {
        public TransactionsProfile()
        {
            CreateMap<Transaction, FullTransactionModel>();
            CreateMap<Transaction, ShortTransactionModel>();
            CreateMap<Transaction, UserTransactionModel>();
            CreateMap<Transaction, AddedTransactionsModel>();
        }
    }
}
