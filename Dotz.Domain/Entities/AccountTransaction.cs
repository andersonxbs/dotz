using Dotz.Domain.Entities.Abstractions;
using Dotz.Domain.Enumerators;

namespace Dotz.Domain.Entities
{
    public class AccountTransaction : EntityBase<long>
    {
        public TransactionType Type { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public int NewBalance { get; set; }

        public long AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
