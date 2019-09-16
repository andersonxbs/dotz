using Dotz.Domain.Entities.Abstractions;
using Dotz.Domain.Enumerators;
using Dotz.Domain.Transients;
using System.Collections.Generic;

namespace Dotz.Domain.Entities
{
    public class Account : EntityBase<long>
    {
        public int PointBalance { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<AccountTransaction> Transactions { get; set; } = new List<AccountTransaction>();

        public OperationResult SetTransaction(
            TransactionType type,
            string description,
            int points)
        {
            var result = new OperationResult();

            if (type == TransactionType.Debit && points > PointBalance)
            {
                result.ErrorDescription = "Your point balance is not enough";
                return result;
            }                

            PointBalance = type == TransactionType.Credit
                ? (PointBalance + points)
                : (PointBalance - points);

            Transactions.Add(new AccountTransaction
            {
                Type = type,
                Description = description,
                Points = points,
                NewBalance = PointBalance
            });

            return result;
        }
    }
}
