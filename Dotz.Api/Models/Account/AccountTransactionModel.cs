using Dotz.Domain.Enumerators;
using System;

namespace Dotz.Api.Models.Account
{
    public class AccountTransactionModel
    {
        public long Id { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public int NewBalance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
